using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    public class BaseScanOrder
    {
        public bool SetResult(string result, List<OrderScanSession> Orders)
        {
            try
            {
                if (CheckedUniqueList(result))
                {
                    String Temp = result.Replace(" ", "");
                    String ReplaceMark = "";

                    String[] ValidationDataMatrix = Temp.Split('_');
                    String[] ExistingCharaterEnglish = new String[] { "A", "a", "B", "C", "c", "E", "e", "H", "K", "M", "O", "o", "P", "p", "T" };
                    String[] ExistingCharaterRussia = new String[] { "А", "а", "В", "С", "с", "Е", "е", "Н", "К", "М", "О", "о", "Р", "р", "Т" };

                    for (int i = 0; i < ExistingCharaterRussia.Length; i++)
                    {
                        ReplaceMark = ValidationDataMatrix[2].Replace(ExistingCharaterRussia[i], ExistingCharaterEnglish[i]);
                    }

                    String[] Splitter = ValidationDataMatrix[1].Split('и');

                    while (Splitter[0][0] == '0')
                    {
                        Splitter[0] = Splitter[0].Remove(0, 1);
                    }

                    if (Splitter.Length != 1)
                    {
                        ValidationDataMatrix[1] = Splitter[0] + "и" + Splitter[1];
                    }
                    else
                    {
                        ValidationDataMatrix[1] = Splitter[0];
                    }

                    Temp = ValidationDataMatrix[0] + "_" + ValidationDataMatrix[1] + "_" + ReplaceMark + "_" + ValidationDataMatrix[3] + "_" + Convert.ToDouble(ValidationDataMatrix[4].Replace(".", ",")).ToString("F2") + "_" + Convert.ToDouble(ValidationDataMatrix[5].Replace(".", ",")).ToString("F2");

                    Int32 IndexException = SystemArgs.Request.CheckedNumberAndList(ValidationDataMatrix[0], ValidationDataMatrix[1], Temp);

                    switch (IndexException)
                    {
                        case 0:
                            if (SystemArgs.Request.CheckedNumberAndMark(ValidationDataMatrix[0], ReplaceMark))
                            {
                                if (ReplaceMark.IndexOf("(?)") == -1)
                                {
                                    if (SystemArgs.SettingsProgram.CheckMarks)
                                    {
                                        if (CheckedLowerRegistery(ReplaceMark))
                                        {
                                            Orders.Add(new OrderScanSession(Temp, 1, "-"));
                                        }
                                        else
                                        {
                                            Orders.Add(new OrderScanSession(Temp, 0, $"Строчные буквы в префиксе марки «{ReplaceMark}» не допускаются"));
                                        }
                                    }
                                    else
                                    {
                                        Orders.Add(new OrderScanSession(Temp, 1, "-"));
                                    }
                                }
                                else
                                {
                                    Orders.Add(new OrderScanSession(Temp, 0, $"Марка требует нумерации"));
                                }
                            }
                            else
                            {
                                Orders.Add(new OrderScanSession(Temp, 0, $"В заказе {ValidationDataMatrix[0]}, марка {ReplaceMark} уже существует."));
                            }

                            break;
                        case 1:
                            Orders.Add(new OrderScanSession(Temp, 0, $"В заказе {ValidationDataMatrix[0]}, номер листа {ValidationDataMatrix[1]} уже существует."));

                            break;
                        case 2:
                            if (ReplaceMark.IndexOf("(?)") == -1)
                            {
                                if (SystemArgs.SettingsProgram.CheckMarks)
                                {
                                    if (CheckedLowerRegistery(ReplaceMark))
                                    {
                                        Orders.Add(new OrderScanSession(Temp, 1, "-"));
                                    }
                                    else
                                    {
                                        Orders.Add(new OrderScanSession(Temp, 0, $"Строчные буквы в префиксе марки «{ReplaceMark}» не допускаются"));
                                    }
                                }
                                else
                                {
                                    Orders.Add(new OrderScanSession(Temp, 1, "-"));
                                }
                            }
                            else
                            {
                                Orders.Add(new OrderScanSession(Temp, 0, $"Марка требует нумерации"));
                            }

                            break;
                        case 3:
                            if (ReplaceMark.IndexOf("(?)") == -1)
                            {
                                if (SystemArgs.SettingsProgram.CheckMarks)
                                {
                                    if (CheckedLowerRegistery(ReplaceMark))
                                    {
                                        Orders.Add(new OrderScanSession(Temp, 2, "-"));
                                    }
                                    else
                                    {
                                        Orders.Add(new OrderScanSession(Temp, 0, $"Строчные буквы в префиксе марки «{ReplaceMark}» не допускаются"));
                                    }
                                }
                                else
                                {
                                    Orders.Add(new OrderScanSession(Temp, 2, "-"));
                                }
                            }
                            else
                            {
                                Orders.Add(new OrderScanSession(Temp, 0, $"Марка требует нумерации"));
                            }

                            break;
                        default:
                            Orders.Add(new OrderScanSession(Temp, 0, "Ошибка добавления чертежа"));

                            break;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception E)
            {
                SystemArgs.PrintLog(E.ToString());
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        readonly List<string> UniqueList = new List<string>();
        private bool CheckedUniqueList(String Temp)
        {
            String[] NumberAndList = Temp.Split('_');

            if (NumberAndList.Length != 6)
            {
                throw new Exception("В DataMatrix менее 6 полей");
            }

            if (UniqueList.Exists(p => p.IndexOf(NumberAndList[0] + "_" + NumberAndList[1]) != -1))
            {
                return false;
            }
            else
            {
                UniqueList.Add(Temp);
                return true;
            }
        }
    }
}
