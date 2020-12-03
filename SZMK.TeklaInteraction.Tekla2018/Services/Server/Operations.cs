using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services;

namespace SZMK.TeklaInteraction.Tekla2018.Services.Server
{
    class Operations
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Request request = new Request();
        private readonly Config config = new Config();
        private User user;
        List<SessionAdded> session;
        public void ShowData(Model Model, User user)
        {
            try
            {
                Views.Main.Main Dialog = new Views.Main.Main();

                TreeNode tree = GetTree(Model);

                Dialog.Data_TV.Nodes.Add(tree);
                Dialog.Count_TB.Text = tree.Nodes.Count.ToString();
                tree.Expand();

                logger.Info("Дерево собрано успешно");

                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    this.user = user;
                    CheckedData(Model);
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
        private void CheckedData(Model Model)
        {
            try
            {
                logger.Info("Начата проверка чертежей");

                session = new List<SessionAdded>();

                for (int i = 0; i < Model.Drawings.Count; i++)
                {
                    if (Model.Drawings.FindAll(p => p.List == Model.Drawings[i].List && p.Order == Model.Drawings[i].Order).Count > 1)
                    {
                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"В заказе {Model.Drawings[i].Order}, лист {Model.Drawings[i].List} уже существует" });
                        continue;
                    }

                    String ReplaceMark = Model.Drawings[i].Mark;

                    String[] ExistingCharaterEnglish = new String[] { "A", "a", "B", "C", "c", "E", "e", "H", "K", "M", "O", "o", "P", "p", "T" };
                    String[] ExistingCharaterRussia = new String[] { "А", "а", "В", "С", "с", "Е", "е", "Н", "К", "М", "О", "о", "Р", "р", "Т" };

                    for (int j = 0; j < ExistingCharaterRussia.Length; j++)
                    {
                        ReplaceMark = ReplaceMark.Replace(ExistingCharaterRussia[j], ExistingCharaterEnglish[j]);
                    }

                    try
                    {
                        String[] Splitter = Model.Drawings[i].List.Split('и');

                        while (Splitter[0][0] == '0')
                        {
                            Splitter[0] = Splitter[0].Remove(0, 1);
                        }

                        if (Splitter.Length != 1)
                        {
                            Model.Drawings[i].List = Splitter[0] + "и" + Splitter[1];
                        }
                        else
                        {
                            Model.Drawings[i].List = Splitter[0];
                        }
                    }
                    catch
                    {
                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = "Поле \"Лист\" не заполнено" });
                        continue;
                    }

                    if (Model.Drawings[i].Executor == "")
                    {
                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = "Поле \"Фамилия\" не заполнено" });
                        continue;
                    }

                    Model.Drawings[i].Model = Model;

                    Int32 IndexException = request.CheckedDrawing(Model.Drawings[i]);

                    switch (IndexException)
                    {
                        case -1:
                            session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = "Ошибка добавления чертежа" });
                            break;
                        case 0:
                            if (request.CheckedNumberAndMark(Model.Drawings[i].Order, ReplaceMark))
                            {
                                if (ReplaceMark.IndexOf("(?)") == -1)
                                {
                                    if (config.CheckMark)
                                    {
                                        if (CheckedLowerRegistery(ReplaceMark))
                                        {
                                            session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 2, Discription = "-" });
                                        }
                                        else
                                        {
                                            session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"Строчные буквы в префиксе марки «{ReplaceMark}» не допускаются" });
                                        }
                                    }
                                    else
                                    {
                                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 2, Discription = "-" });
                                    }
                                }
                                else
                                {
                                    session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"Марка требует нумерации" });
                                }
                            }
                            else
                            {
                                session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"В заказе {Model.Drawings[i].Order}, марка {ReplaceMark} уже существует." });
                            }
                            break;
                        case 1:
                            session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"В заказе {Model.Drawings[i].Order}, номер листа {Model.Drawings[i].List} уже существует." });
                            break;
                        case 2:
                            if (ReplaceMark.IndexOf("(?)") == -1)
                            {
                                if (config.CheckMark)
                                {
                                    if (CheckedLowerRegistery(ReplaceMark))
                                    {
                                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 2, Discription = "-" });
                                    }
                                    else
                                    {
                                        session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"Строчные буквы в префиксе марки «{ReplaceMark}» не допускаются" });
                                    }
                                }
                                else
                                {
                                    session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 2, Discription = "-" });
                                }
                            }
                            else
                            {
                                session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"Марка требует нумерации" });
                            }
                            break;
                        case 3:
                            Views.Main.Update Update = new Views.Main.Update();

                            Update.NewOrder_TB.Text = Model.Drawings[i].ToString();
                            Update.OldOrder_TB.Text = request.GetDataMatrix(Model.Drawings[i].Order, Model.Drawings[i].List);

                            if (Update.ShowDialog() == DialogResult.OK)
                            {
                                session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 1, Discription = "-" });
                            }
                            else
                            {
                                session.Add(new SessionAdded { Drawing = Model.Drawings[i], Unique = 0, Discription = $"В заказе {Model.Drawings[i].Order}, номер листа {Model.Drawings[i].List} уже существует." });
                            }

                            break;
                    }
                }
                logger.Info("Проверка чертежей успешна");

                AddData(session);
            }
            catch (Exception E)
            {
                session.Clear();
                throw new Exception(E.Message, E);
            }
        }
        private TreeNode GetTree(Model model)
        {
            TreeNode parentNode = new TreeNode
            {
                Text = model.Path
            };

            for (int i = 0; i < model.Drawings.Count; i++)
            {
                TreeNode drawingNode = new TreeNode
                {
                    Text = "DataMatrix: " + model.Drawings[i].ToString()
                };

                drawingNode.Nodes.Add("Заказ: " + model.Drawings[i].Order);
                drawingNode.Nodes.Add("Место: " + model.Drawings[i].Place);
                drawingNode.Nodes.Add("Лист: " + model.Drawings[i].List);
                drawingNode.Nodes.Add("Наименование: " + model.Drawings[i].Assembly);
                drawingNode.Nodes.Add("Разработчик: " + model.Drawings[i].Executor);
                drawingNode.Nodes.Add("Масса марки: " + model.Drawings[i].WeightMark);
                drawingNode.Nodes.Add("Кол-во марок: " + model.Drawings[i].CountMark);
                drawingNode.Nodes.Add("Масса итого: " + model.Drawings[i].SubTotalWeight);
                drawingNode.Nodes.Add("Кол-во деталей в марке: " + model.Drawings[i].CountDetail);

                TreeNode details = new TreeNode
                {
                    Text = "Детали"
                };

                for (int j = 0; j < model.Drawings[i].Details.Count; j++)
                {
                    TreeNode detail = new TreeNode
                    {
                        Text = "Позиция детали: " + model.Drawings[i].Details[j].Position
                    };
                    detail.Nodes.Add("Кол-во деталей: " + model.Drawings[i].Details[j].Count);
                    detail.Nodes.Add("Профиль: " + model.Drawings[i].Details[j].Profile);
                    detail.Nodes.Add("Ширина: " + model.Drawings[i].Details[j].Width);
                    detail.Nodes.Add("Длина: " + model.Drawings[i].Details[j].Lenght);
                    detail.Nodes.Add("Масса 1шт: " + model.Drawings[i].Details[j].Weight);
                    detail.Nodes.Add("Масса всех: " + model.Drawings[i].Details[j].SubtotalWeight);
                    detail.Nodes.Add("Марка стали: " + model.Drawings[i].Details[j].MarkSteel);
                    detail.Nodes.Add("Примечание: " + model.Drawings[i].Details[j].Discription);
                    detail.Nodes.Add("Г.М. длина: " + model.Drawings[i].Details[j].GMlenght);
                    detail.Nodes.Add("Г.М. ширина: " + model.Drawings[i].Details[j].GMwidth);
                    detail.Nodes.Add("Г.М. высота: " + model.Drawings[i].Details[j].GMheight);
                    detail.Nodes.Add("Мех. обр.: " + model.Drawings[i].Details[j].Machining);
                    detail.Nodes.Add("Способ покраски RAL: " + model.Drawings[i].Details[j].MethodOfPaintingRAL);
                    detail.Nodes.Add("Площадь покраски: " + model.Drawings[i].Details[j].PaintingArea);

                    details.Nodes.Add(detail);
                }

                drawingNode.Nodes.Add(details);

                parentNode.Nodes.Add(drawingNode);
            }

            return parentNode;
        }
        private bool CheckedLowerRegistery(String Mark)
        {
            String LowerCharacters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < Mark.Length; i++)
            {
                if (LowerCharacters.IndexOf(Mark[i]) != -1)
                {
                    return false;
                }
            }
            return true;

        }
        private void AddData(List<SessionAdded> Session)
        {
            try
            {
                logger.Info("Начато добавление чертежей");

                Int64 IndexOrder = -1;

                for (int i = 0; i < Session.Count; i++)
                {
                    try
                    {
                        if (Session[i].Unique == 2)
                        {
                            IndexOrder = request.GetAutoIDDrawing();

                            String[] ListCanceled = Session[i].Drawing.List.Split('и');

                            if (ListCanceled.Length != 1)
                            {
                                List<Drawing> CanceledDrawings = request.GetCanceledDrawings(ListCanceled[0], Session[i].Drawing.Order);

                                if (CanceledDrawings.Count() > 0)
                                {
                                    for (Int32 j = 0; j < CanceledDrawings.Count; j++)
                                    {
                                        request.CanceledDrawing(CanceledDrawings[j]);
                                    }
                                }
                            }

                            Status TempStatus = user.StatusesUser.First();

                            Session[i].Drawing.Id = request.GetAutoIDDrawing() + 1;

                            Session[i].Drawing.TypeAdd = request.GetTypeAdd("Tekla Interaction");

                            if (!request.ModelExist(Session[i].Drawing.Model))
                            {
                                request.InsertModel(Session[i].Drawing.Model);
                            }

                            Session[i].Drawing.Model = request.GetModel(Session[i].Drawing.Model);

                            if (request.InsertDrawing(Session[i].Drawing))
                            {
                                for (int countMark = 0; countMark < Session[i].Drawing.CountMark; countMark++)
                                {
                                    for (int j = 0; j < Session[i].Drawing.Details.Count; j++)
                                    {
                                        Session[i].Drawing.Details[j].ID = request.GetAutoIDDetail() + 1;

                                        request.InsertDetail(Session[i].Drawing.Details[j]);
                                        request.InsertAddDetail(Session[i].Drawing, Session[i].Drawing.Details[j]);
                                    }
                                }

                                if (!request.StatusExist(Session[i].Drawing, user))
                                {
                                    request.InsertStatus(Session[i].Drawing, user);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при добавлении в базу данных DataMatrix: " + Session[i].Drawing.ToString(), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else if (Session[i].Unique == 1)
                        {
                            request.UpdateDrawing(Session[i].Drawing);
                            request.DownGradeStatus(Session[i].Drawing, user);
                        }
                    }
                    catch (Exception E)
                    {
                        Session[i].Discription = E.Message;
                        Session[i].Unique = 0;
                    }

                }

                logger.Info("Добавление чертежей прошло успешно");

                List<SessionAdded> Temp = Session.Where(p => p.Unique == 0).ToList();
                if (Temp.Count() > 0)
                {
                    logger.Info("Выполнен показ отчета не добавленных чертежей");

                    Views.Main.Report Report = new Views.Main.Report();
                    Report.Report_DGV.AutoGenerateColumns = false;
                    Report.Report_DGV.DataSource = Temp;
                    Report.CountOrder_TB.Text = Session.Count() - Temp.Count() + "/" + Session.Count();
                    Report.ShowDialog();

                }

                if (Session.Count > Temp.Count)
                {
                    MessageBox.Show("Добавление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Session.Clear();
            }
            catch (Exception E)
            {
                Session.Clear();
                throw new Exception(E.Message, E);
            }
        }
    }
}
