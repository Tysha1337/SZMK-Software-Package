using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Services;
using SZMK.TeklaInteraction.Tekla2018.Services.Server.Interfaces;
using SZMK.TeklaInteraction.Tekla2018.Views.Shared.Interfaces;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;
using ModelObject = Tekla.Structures.Model.ModelObject;

namespace SZMK.TeklaInteraction.Tekla2018.Services.Server
{
    class Tekla : ITekla
    {
        private readonly Logger logger;
        private readonly MailLogger maillogger;
        private readonly INotifyProgress notify;

        public Tekla(INotifyProgress notify)
        {
            logger = LogManager.GetCurrentClassLogger();
            maillogger = new MailLogger();
            this.notify = notify;
        }

        Model model;
        DrawingHandler CourretDrawingHandler;

        Shared.Models.Model Model;
        public List<Shared.Models.Drawing> Drawings;

        public bool CheckConnect()
        {
            model = new Model();
            CourretDrawingHandler = new DrawingHandler();

            if (model.GetConnectionStatus() && CourretDrawingHandler.GetConnectionStatus())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetData(Shared.Models.User user)
        {
            try
            {
                DrawingEnumerator SelectedDrawings = CourretDrawingHandler.GetDrawingSelector().GetSelected();

                logger.Info("Чертежи успешно получены");

                Drawings = new List<Shared.Models.Drawing>();

                while (SelectedDrawings.MoveNext())
                {
                    try
                    {

                        if (SelectedDrawings.Current is AssemblyDrawing)
                        {

                            String Number = "";

                            Assembly assembly = model.SelectModelObject(((SelectedDrawings.Current as AssemblyDrawing)).AssemblyIdentifier) as Assembly;

                            if (!ChechedDate(assembly))
                            {
                                assembly.GetReportProperty("CUSTOM.Zakaz", ref Number);
                                MessageBox.Show("Не заполнено поле \"Дата\" в чертеже: " + Number + " " + SelectedDrawings.Current.Mark, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            GetDrawing(assembly, SelectedDrawings.Current as AssemblyDrawing);
                        }
                    }
                    catch (Exception E)
                    {
                        String Number = "";
                        String List = "";
                        Assembly assembly = model.SelectModelObject(((SelectedDrawings.Current as AssemblyDrawing)).AssemblyIdentifier) as Assembly;
                        assembly.GetReportProperty("CUSTOM.Zakaz", ref Number);
                        assembly.GetReportProperty("CUSTOM.Drw_SheetRev", ref List);
                        logger.Error(E.ToString());
                        MessageBox.Show("Ошибка в чертеже:" + Environment.NewLine + "Заказ " + Number + Environment.NewLine + "Лист " + List + Environment.NewLine + "Проверьте его параметры" + Environment.NewLine + "Пояснение ошибки: " + E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                logger.Info("Чертежи добавлены");

                ModelInfo modelInfo = model.GetInfo();
                Model = new Shared.Models.Model { Path = modelInfo.ModelPath, Drawings = Drawings };

                notify.Close();

                if (Model.Drawings.Count() > 0)
                {
                    logger.Info("Начат показ чертежей");

                    Operations operations = new Operations();
                    operations.ShowData(Model, user);
                }
            }
            catch (Exception E)
            {
                maillogger.SendErrorLog(E.ToString());
                logger.Error(E.ToString());
                MessageBox.Show("Ошибка операции", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Shared.Models.Detail> AddMainDetailDrawingObjects(AssemblyDrawing parentDrawing)
        {
            try
            {
                List<Shared.Models.Detail> Details = new List<SZMK.TeklaInteraction.Shared.Models.Detail>();

                Assembly assembly = model.SelectModelObject(parentDrawing.AssemblyIdentifier) as Assembly;

                ModelObject modelObject = assembly.GetMainPart();

                Details.Add(GetDetailAttribute(modelObject, 1));

                AddsSecondariesDrawingObjectsToTreeNode(assembly, Details);

                return Details;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private void AddsSecondariesDrawingObjectsToTreeNode(Assembly assembly, List<SZMK.TeklaInteraction.Shared.Models.Detail> Details)
        {
            try
            {
                ArrayList secondaries = assembly.GetSecondaries();

                string _position = "";

                for (int i = 0; i < secondaries.Count; i++)
                {
                    ModelObject modelObject = secondaries[i] as ModelObject;

                    modelObject.GetReportProperty("PART_POS", ref _position);

                    int CountDetail = 0;

                    if (Details.Where(p => p.Position == _position).Count() > 0)
                    {
                        CountDetail = Details.Where(p => p.Position == _position).FirstOrDefault().Count;

                        Details.RemoveAll(p => p.Position == _position);
                    }

                    Details.Add(GetDetailAttribute(modelObject, CountDetail + 1));
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private Shared.Models.Detail GetDetailAttribute(ModelObject modelObject, Int32 CountDetail)
        {
            try
            {
                string _position = "";
                string _profile = "";
                double _width = 0;
                double _lenght = 0;
                double _weight = 0;
                double _subTotalWeight = 0;
                string _markSteel = "";
                string _discription = "";
                double _gmlenght = 0;
                double _gmwidth = 0;
                double _gmheight = 0;
                string _machining = "";
                string _methodOfPaintingRAL = "";
                double _paintingArea = 0;

                modelObject.GetReportProperty("PART_POS", ref _position);
                _profile = GetProfile(modelObject);
                modelObject.GetReportProperty("WIDTH", ref _width);
                modelObject.GetReportProperty("LENGTH", ref _lenght);
                modelObject.GetReportProperty("CUSTOM.SZ_PartWeight", ref _weight);
                modelObject.GetReportProperty("MATERIAL", ref _markSteel);
                _discription = GetDiscriptrion(modelObject);
                modelObject.GetReportProperty("ASSEMBLY.LENGTH", ref _gmlenght);
                modelObject.GetReportProperty("ASSEMBLY.WIDTH", ref _gmwidth);
                modelObject.GetReportProperty("ASSEMBLY.HEIGHT", ref _gmheight);
                _machining = GetMachining(modelObject);
                _methodOfPaintingRAL = GetMethodOfPainting(modelObject);
                modelObject.GetReportProperty("ASSEMBLY.AREA", ref _paintingArea);
                _subTotalWeight = CountDetail * _weight;

                return new Shared.Models.Detail { Position = _position, Profile = _profile, Width = Convert.ToDouble(_width.ToString("F2")), Lenght = Convert.ToDouble(_lenght.ToString("F2")), Weight = Convert.ToDouble(_weight.ToString("F2")), SubtotalWeight = Convert.ToDouble(_subTotalWeight.ToString("F2")), MarkSteel = _markSteel, Discription = _discription, GMlenght = Convert.ToDouble(_gmlenght.ToString("F2")), GMwidth = Convert.ToDouble(_gmwidth.ToString("F2")), GMheight = Convert.ToDouble(_gmheight.ToString("F2")), Machining = _machining, MethodOfpPaintingRAL = _methodOfPaintingRAL, PaintingArea = Convert.ToDouble((_paintingArea / 1000000).ToString("F2")), Count = CountDetail };
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool GetDrawing(Assembly assembly, AssemblyDrawing parentDrawing)
        {
            try
            {
                string _dataMatrix = "";
                string _assembly = "";
                string _order = "";
                string _place = "";
                string _list = "";
                string _mark = "";
                string _executor = "";
                double _weightMark = 0;
                int _countMark = 0;
                double _subTotalWeight = 0;
                int _countDetail = 0;

                double _lenght = 0;

                assembly.GetReportProperty("LENGTH", ref _lenght);

                _assembly = assembly.Name;

                assembly.GetReportProperty("CUSTOM.Zakaz", ref _order);

                if (!CheckedOrder(_order))
                {
                    throw new Exception($"Ошибочное указание заказа: {_order}");
                }

                assembly.GetReportProperty("DRAWING.USERDEFINED.ru_mesto", ref _place);
                assembly.GetReportProperty("CUSTOM.Drw_SheetRev", ref _list);

                string[] splitter = _list.Split('и');

                while (splitter[0][0] == '0')
                {
                    splitter[0] = splitter[0].Remove(0, 1);
                }

                if (splitter.Length != 1)
                {
                    _list = splitter[0] + "и" + splitter[1];
                }
                else
                {
                    _list = splitter[0];
                }

                assembly.GetReportProperty("ASSEMBLY_POS", ref _mark);
                assembly.GetReportProperty("DRAWING.USERDEFINED.ru_11_fam_dop", ref _executor);

                if (!CheckedExecutor(_executor))
                {
                    throw new Exception($"Исполнитель не указан");
                }
                else
                {
                    _executor = _executor.Replace(" ", "");
                    _executor = _executor.Insert(_executor.IndexOf('.') - 1, " ");
                }

                assembly.GetReportProperty("CUSTOM.SZ_AssWeight", ref _weightMark);
                assembly.GetReportProperty("MODEL_TOTAL", ref _countMark);

                _subTotalWeight = _weightMark * _countMark;

                _dataMatrix = $"{_order}_{_list}_{_mark}_{_executor}_{_lenght:F2}_{_subTotalWeight:F2}";

                if (!CheckedUnique(_dataMatrix))
                {
                    throw new Exception("Чертеж " + _dataMatrix + " уже существует");
                }

                List<Shared.Models.Detail> Details = AddMainDetailDrawingObjects(parentDrawing);

                _countDetail = Details.Sum(p => p.Count);

                Drawings.Add(new Shared.Models.Drawing { DataMatrix = _dataMatrix, Assembly = _assembly, Order = _order, Place = _place, List = _list, Mark = _mark, Executor = _executor, WeightMark = Convert.ToDouble(_weightMark.ToString("F2")), CountMark = _countMark, SubTotalWeight = Convert.ToDouble(_subTotalWeight.ToString("F2")), CountDetail = _countDetail, Details = Details });

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool ChechedDate(Assembly assembly)
        {
            try
            {
                string StringAnswer = "";
                assembly.GetReportProperty("DRAWING.USERDEFINED.ru_date", ref StringAnswer);
                if (String.IsNullOrEmpty(StringAnswer))
                {
                    return false;
                }
                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool CheckedUnique(string dataMatrix)
        {
            try
            {
                if (Drawings.Where(p => p.DataMatrix == dataMatrix).Count() != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        public bool CheckedOrder(string order)
        {
            try
            {
                int firstNum = Convert.ToInt32(order.Substring(0, order.IndexOf('(')));
                int secondNum = Convert.ToInt32(order.Substring(order.IndexOf('(') + 1, order.IndexOf(')') - order.IndexOf('(')-1));

                string lastNum = order.Remove(0, order.IndexOf(')') + 1);

                if (!String.IsNullOrEmpty(lastNum))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool CheckedExecutor(string executor)
        {
            try
            {
                if (String.IsNullOrEmpty(executor))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private String GetProfile(ModelObject modelObject)
        {
            string Profile = "";
            modelObject.GetReportProperty("PROFILE", ref Profile);
            try
            {
                string StringAnswer = "";
                double DoubleAnswer = 0;
                int IntAnswer = 0;

                int Index = -1;
                string GostName = "";

                modelObject.GetReportProperty("PROFILE.GOST_NAME", ref GostName);

                String[] Arguments = new String[] { "PL", "Утеплит", "Риф", "Сетка 50/50х2.5 В=1800", "ПВ", "ГОСТ 8509-93", "ГОСТ 8510-93", "PD", "Профиль(кв.)", "Профиль", "*" };
                for (int i = 0; i < Arguments.Length; i++)
                {
                    if (Arguments[i].IndexOf("ГОСТ") == -1)
                    {
                        if (Profile.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                    else
                    {
                        if (GostName.IndexOf(Arguments[i]) != -1)
                        {
                            Index = i;
                            break;
                        }
                    }
                }
                switch (Index)
                {
                    case 0:
                        Double var4 = 0;
                        Double var5 = 0;
                        Profile = Profile.Replace(".", ",");
                        var4 = Convert.ToDouble(Profile.Substring(2, Profile.IndexOf("*") - 2));
                        var5 = Convert.ToDouble(Profile.Substring(1 + Profile.IndexOf("*"), Profile.Length - Profile.IndexOf("*") - 1));
                        if (var4 > var5)
                        {
                            return "-" + var5.ToString();
                        }
                        else
                        {
                            return "-" + var4.ToString();
                        }
                    case 1:
                        modelObject.GetReportProperty("MATERIAL", ref StringAnswer);
                        return StringAnswer;
                    case 2:
                        modelObject.GetReportProperty("MATERIAL", ref StringAnswer);
                        return StringAnswer;
                    case 3:
                        return "Сетка 50/50х2.5 В=1800";
                    case 4:
                        modelObject.GetReportProperty("MATERIAL", ref StringAnswer);
                        return StringAnswer;
                    case 5:
                        modelObject.GetReportProperty("PROFILE.WIDTH", ref DoubleAnswer);
                        StringAnswer = "L" + DoubleAnswer.ToString("F0") + "x";
                        modelObject.GetReportProperty("PROFILE.FLANGE_THICKNESS_1", ref DoubleAnswer);
                        StringAnswer += DoubleAnswer.ToString("F0");
                        return StringAnswer;
                    case 6:
                        modelObject.GetReportProperty("PROFILE.WIDTH", ref DoubleAnswer);
                        StringAnswer = "L" + DoubleAnswer.ToString("F0") + "x";
                        modelObject.GetReportProperty("PROFILE.WIDTH", ref DoubleAnswer);
                        StringAnswer += DoubleAnswer.ToString("F0") + "x";
                        modelObject.GetReportProperty("PROFILE.FLANGE_THICKNESS_1", ref DoubleAnswer);
                        StringAnswer += DoubleAnswer.ToString("F0");
                        return StringAnswer;
                    case 7:
                        modelObject.GetReportProperty("PROFILE.DIAMETER", ref IntAnswer);
                        modelObject.GetReportProperty("PROFILE.PLATE_THICKNESS", ref DoubleAnswer);
                        StringAnswer = "Труба " + DoubleAnswer.ToString("F2") + "x" + DoubleAnswer.ToString("F2");
                        return StringAnswer;
                    case 8:
                        modelObject.GetReportProperty("PROFILE.HEIGHT", ref DoubleAnswer);
                        modelObject.GetReportProperty("PROFILE.PLATE_THICKNESS", ref DoubleAnswer);
                        StringAnswer = "Тр.кв." + DoubleAnswer.ToString("F2") + "x" + DoubleAnswer.ToString("F2");
                        return StringAnswer;
                    case 9:
                        modelObject.GetReportProperty("PROFILE.HEIGHT", ref DoubleAnswer);
                        StringAnswer = "Тр.пр." + DoubleAnswer.ToString("F2") + "x";
                        modelObject.GetReportProperty("PROFILE.HEIGHT", ref DoubleAnswer);
                        modelObject.GetReportProperty("PROFILE.PLATE_THICKNESS", ref DoubleAnswer);
                        StringAnswer += DoubleAnswer.ToString("F2") + "x" + DoubleAnswer.ToString("F2");
                        return StringAnswer;
                    case 10:
                        StringAnswer = Profile.Replace("*", "x");
                        return StringAnswer;
                }
                return Profile;
            }
            catch
            {
                return Profile;
            }
        }
        private String GetDiscriptrion(ModelObject modelObject)
        {
            try
            {
                int IntAnswer = 0;
                modelObject.GetReportProperty("HAS_HOLES", ref IntAnswer);
                if (IntAnswer == 0)
                {
                    return "";
                }
                else
                {
                    return "Отв. ";
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private String GetMachining(ModelObject modelObject)
        {
            try
            {
                string StringAnswer = "";
                modelObject.GetReportProperty("PROFILE_TYPE", ref StringAnswer);
                string tempA = "";
                string tempB = "";
                if (StringAnswer == "B")
                {
                    modelObject.GetReportProperty("VOLUME", ref tempA);
                    modelObject.GetReportProperty("VOLUME_NET", ref tempB);
                    if (tempA == tempB)
                    {
                        StringAnswer = "";
                    }
                    else
                    {
                        StringAnswer = "Фаска/Стр. ";
                    }
                }
                else
                {
                    StringAnswer = "";
                }
                modelObject.GetReportProperty("USERDEFINED.comment", ref tempA);
                if (tempA == "0")
                {
                    return StringAnswer += "";
                }
                else
                {
                    return StringAnswer += tempA;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private String GetMethodOfPainting(ModelObject modelObject)
        {
            try
            {
                string StringAnswer = "";
                modelObject.GetReportProperty("ASSEMBLY.MAINPART.FINISH", ref StringAnswer);
                if (StringAnswer == "")
                {
                    modelObject.GetReportProperty("USERDEFINED.Obrabotka", ref StringAnswer);
                    return StringAnswer;
                }
                else
                {
                    return StringAnswer;
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }

    }
}
