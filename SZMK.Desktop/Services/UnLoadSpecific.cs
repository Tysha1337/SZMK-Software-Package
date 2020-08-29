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
            public List<Specific> GetSpecific()
            {
                return _Specifics;
            }
        }
        struct Unloading
        {
            public String _List;
            public String _Detail;

            public Unloading(String List, String Detail)
            {
                _List = List;
                _Detail = Detail;
            }
        }
        public List<ExecutorMail> ExecutorMails;
        public UnLoadSpecific()
        {
            ExecutorMails = new List<ExecutorMail>();
        }
        public bool SearchFileUnloading(List<String> SessionForCheckingUnloading)
        {
            SystemArgs.UnLoadSpecific.ExecutorMails.Clear();
            Boolean flag = false;
            for (int i = 0; i < SessionForCheckingUnloading.Count; i++)
            {
                String[] SplitDataMatrix = SessionForCheckingUnloading[i].Split('_');
                String pathSpecific = SystemArgs.SettingsUser.ModelsPath;
                String[] directories = Directory.GetDirectories(pathSpecific);

                foreach (var directory in directories)
                {
                    if (SystemArgs.Path.GetFileName(directory).Replace(" ", "").IndexOf(SplitDataMatrix[0].Remove(SplitDataMatrix[0].IndexOf('('), SplitDataMatrix[0].Length - SplitDataMatrix[0].IndexOf('('))) != -1)
                    {
                        if (SystemArgs.Path.GetFileName(directory).Replace(" ", "").Remove(SystemArgs.Path.GetFileName(directory).IndexOf(SplitDataMatrix[0].Remove(SplitDataMatrix[0].IndexOf('('), SplitDataMatrix[0].Length - SplitDataMatrix[0].IndexOf('('))), SplitDataMatrix[0].Remove(SplitDataMatrix[0].IndexOf('('), SplitDataMatrix[0].Length - SplitDataMatrix[0].IndexOf('(')).Length).IndexOf(SplitDataMatrix[0].Remove(0, SplitDataMatrix[0].IndexOf("(") + 1).Replace(")", "")) != -1)
                        {
                            pathSpecific = directory + @"\Отчеты\#Для выгрузки.xml";
                            break;
                        }
                        else
                        {
                            foreach(var subdir in Directory.GetDirectories(directory))
                            {
                                if(subdir.Replace(" ", "").IndexOf(SplitDataMatrix[0].Remove(SplitDataMatrix[0].IndexOf('('), SplitDataMatrix[0].Length - SplitDataMatrix[0].IndexOf('('))) != -1)
                                {
                                    if (SystemArgs.Path.GetFileName(subdir).Replace(" ","").Replace(SplitDataMatrix[0].Remove(SplitDataMatrix[0].IndexOf('('), SplitDataMatrix[0].Length - SplitDataMatrix[0].IndexOf('(')),"").IndexOf(SplitDataMatrix[0].Remove(0,SplitDataMatrix[0].IndexOf("(")+1).Replace(")","")) != -1)
                                    {
                                        pathSpecific = subdir + @"\Отчеты\#Для выгрузки.xml";
                                        break;
                                    }
                                }
                            }
                            if (!SystemArgs.SettingsUser.ModelsPath.Equals(pathSpecific))
                            {
                                break;
                            }
                        }
                    }
                }

                if (!File.Exists(pathSpecific))
                {
                    if (MessageBox.Show("Папки с номером заказа " + SplitDataMatrix[0] + " не существует" + Environment.NewLine + "Указать файл выгрузки вручную?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Xlm Files .xml |*.xml";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            pathSpecific = ofd.FileName;
                            ChekedUnloading(SplitDataMatrix, pathSpecific);
                            flag = true;
                        }
                    }
                }
                else
                {
                    ChekedUnloading(SplitDataMatrix, pathSpecific);
                    flag = true;
                }
            }
            return flag;
        }
        private void ChekedUnloading(String[] SplitDataMatrix, String pathSpecific)
        {
            String List = "";
            String Detail = "";
            List<Unloading> Temp = new List<Unloading>();
            XDocument doc = XDocument.Load(pathSpecific);
            foreach (XElement el in doc.Element("Export").Elements("Сборка"))
            {
                foreach (XElement xml in el.Elements("Деталь"))
                {
                    List = el.Element("Лист").Value.Trim();
                    Detail = xml.Element("Позиция_детали").Value.Trim();
                    Temp.Add(new Unloading(List, Detail));
                }
            }
            pathSpecific = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(pathSpecific));
            if (Temp.Count() > 1)
            {
                for (int j = 0; j < Temp.Count; j++)
                {
                    if (Temp[j]._List.Equals(SplitDataMatrix[1]))
                    {
                        if (Temp[j]._Detail != null)
                        {
                            if (File.Exists(pathSpecific + @"\Чертежи\Детали PDF\" + "Дет." + Temp[j]._Detail + ".pdf"))
                            {
                                if (ExecutorMails.Where(p => p.Executor.Equals(SplitDataMatrix[3])).Count() != 0)
                                {
                                    foreach (var item in SystemArgs.UnLoadSpecific.ExecutorMails)
                                    {
                                        if (SplitDataMatrix[3].Equals(item.Executor))
                                        {
                                            item.GetSpecific().Add(new Specific(SplitDataMatrix[0], Temp[j]._List, Convert.ToInt64(Temp[j]._Detail), true));
                                        }
                                    }
                                }
                                else
                                {
                                    ExecutorMails.Add(new ExecutorMail(SplitDataMatrix[3]));
                                    ExecutorMails[ExecutorMails.Count() - 1].GetSpecific().Add(new Specific(SplitDataMatrix[0], Temp[j]._List, Convert.ToInt64(Temp[j]._Detail), true));
                                }
                            }
                            else
                            {
                                if (ExecutorMails.Where(p => p.Executor.Equals(SplitDataMatrix[3])).Count() != 0)
                                {
                                    foreach (var item in ExecutorMails)
                                    {
                                        if (SplitDataMatrix[3].Equals(item.Executor))
                                        {
                                            item.GetSpecific().Add(new Specific(SplitDataMatrix[0], Temp[j]._List, Convert.ToInt64(Temp[j]._Detail), false));
                                        }
                                    }
                                }
                                else
                                {
                                    ExecutorMails.Add(new ExecutorMail(SplitDataMatrix[3]));
                                    ExecutorMails[ExecutorMails.Count() - 1].GetSpecific().Add(new Specific(SplitDataMatrix[0], Temp[j]._List, Convert.ToInt64(Temp[j]._Detail), false));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
