using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.Services
{
    /*Класс для определения выгрузки деталей с методом проверки а также структурой для хранения исполнителя деталей и все детали в ней*/
    public class UnLoadSpecific
    {
        public struct ExecutorMail
        {
            private String _Executor;
            private List<Specific> _Specifics;
            public ExecutorMail(String Executor)
            {
                if (!String.IsNullOrEmpty(Executor))
                {
                    _Executor = Executor;
                }
                else
                {
                    throw new Exception("Не задан исполнитель");
                }
                _Specifics = new List<Specific>();
            }
            public String Executor
            {
                get
                {
                    return _Executor;
                }
                set
                {
                    if (!String.IsNullOrEmpty(Executor))
                    {
                        _Executor = value;
                    }
                }
            }
            public Specific this[Int32 Index]
            {
                get
                {
                    return _Specifics[Index];
                }
                set
                {
                    if (value != null)
                    {
                        _Specifics[Index] = value;
                    }
                }
            }
            public List<Specific> GetSpecifics()
            {
                return _Specifics;
            }
        }

        public List<ExecutorMail> ExecutorMails;
        public UnLoadSpecific()
        {
            ExecutorMails = new List<ExecutorMail>();
        }

        public void ChekedUnloading(String Number, String List, String Executor)
        {
            Int64 IDOrder = SystemArgs.Request.GetIDOrder(Number, List);
            string pathModel = SystemArgs.Request.GetOrder(List, Number).Model.Path;
            List<Detail> details = SystemArgs.Request.GetDetails(IDOrder);


            if (details.GroupBy(p => p.Position).Count() > 1 || details.FindAll(p => p.Count > 1).Count > 0)
            {
                for (int j = 0; j < details.Count; j++)
                {
                    if (details[j] != null)
                    {
                        if (CheckedDetail(pathModel, details[j].Position.ToString(), Number))
                        {
                            if (ExecutorMails.Where(p => p.Executor.Equals(Executor)).Count() != 0)
                            {
                                foreach (var item in SystemArgs.UnLoadSpecific.ExecutorMails)
                                {
                                    if (Executor.Equals(item.Executor))
                                    {
                                        item.GetSpecifics().Add(new Specific(Number, List, details[j].Position, true));
                                    }
                                }
                            }
                            else
                            {
                                ExecutorMails.Add(new ExecutorMail(Executor));
                                ExecutorMails[ExecutorMails.Count() - 1].GetSpecifics().Add(new Specific(Number, List, details[j].Position, true));
                            }
                        }
                        else
                        {
                            if (ExecutorMails.Where(p => p.Executor.Equals(Executor)).Count() != 0)
                            {
                                foreach (var item in ExecutorMails)
                                {
                                    if (Executor.Equals(item.Executor))
                                    {
                                        item.GetSpecifics().Add(new Specific(Number, List, details[j].Position, false));
                                    }
                                }
                            }
                            else
                            {
                                ExecutorMails.Add(new ExecutorMail(Executor));
                                ExecutorMails[ExecutorMails.Count() - 1].GetSpecifics().Add(new Specific(Number, List, details[j].Position, false));
                            }
                        }
                    }
                }
            }
        }
        private bool CheckedDetail(string pathModel, string Position, string Number)
        {
            if (File.Exists(pathModel + @"\Чертежи\Детали PDF\" + "Дет." + Position + ".pdf"))
            {
                return true;
            }
            else if (File.Exists(pathModel + @"\Чертежи\" + Number + @"\Детали PDF\" + "Дет." + Position + ".pdf"))
            {
                return true;
            }
            else if (Directory.GetFiles(pathModel + @"\Чертежи\" + Number + @"\Детали PDF", Position + " - Дет.*.pdf", SearchOption.TopDirectoryOnly).Length != 0)
            {
                return true;
            }
            else if (Directory.GetFiles(pathModel + @"\Чертежи\Детали PDF", Position + " - Дет.*.pdf", SearchOption.TopDirectoryOnly).Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
