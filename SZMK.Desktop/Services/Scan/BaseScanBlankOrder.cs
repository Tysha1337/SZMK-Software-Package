using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Services.Scan
{
    public class BaseScanBlankOrder
    {
        private List<BlankOrderScanSession> _BlankOrders;
        public bool SetResult(string result, bool Added, List<BlankOrderScanSession> BlankOrders)
        {
            try
            {
                _BlankOrders = BlankOrders;

                String Temp = result.Replace("\u00a0", "").Replace(" ", "");
                String[] ValidationDataMatrix = Temp.Split('_');
                if (ValidationDataMatrix.Length >= 4)
                {
                    Regex regex = new Regex(@"\d*-\d*-\d*");
                    MatchCollection matches = regex.Matches(ValidationDataMatrix[1]);

                    if (matches.Count > 0)
                    {
                        Temp = ValidationDataMatrix[0] + "_СЗМК";
                        for (int i = 1; i < ValidationDataMatrix.Length; i++)
                        {
                            Temp += "_" + ValidationDataMatrix[i];
                        }
                        ValidationDataMatrix = Temp.Split('_');
                    }

                    if (CheckedUniqueList(Temp, _BlankOrders))
                    {
                        _BlankOrders.Add(new BlankOrderScanSession(true, Temp));

                        if (Added)
                        {
                            if (ValidationDataMatrix[0] != "ПО")
                            {
                                if (ValidationDataMatrix[1] != "СЗМК" && ValidationDataMatrix[0] == "БЗ")
                                {
                                    if (!FindedOrderBlankProvider(ValidationDataMatrix, Temp))
                                    {
                                        throw new Exception("Ошибка определения чертежей в бланке поставщику");
                                    }
                                }
                                else if (ValidationDataMatrix[0] == "БЗ")
                                {
                                    if (!FindedOrderBlankOrder(ValidationDataMatrix, Temp))
                                    {
                                        throw new Exception("Ошибка определения чертежей в бланке заказа");
                                    }
                                }
                                else
                                {
                                    _BlankOrders[_BlankOrders.Count - 1].Added = false;
                                    throw new Exception("Неверный формат бланка заказа");
                                }
                            }
                            else
                            {
                                if (!FindedOrderCreditOrder(ValidationDataMatrix, Temp))
                                {
                                    throw new Exception("Ошибка определения чертежей в приходном ордере");
                                }
                            }
                        }
                        else if (ValidationDataMatrix[0] == "БЗ")
                        {
                            if (!FindedBlankOrder_OPP(ValidationDataMatrix, Temp))
                            {
                                throw new Exception("Ошибка определения чертежей в бланке заказа");
                            }
                        }
                        else
                        {
                            throw new Exception("Неверный формат бланка заказа");
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("В QR менее 4 полей");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CheckedUniqueList(String Temp, List<BlankOrderScanSession> _Orders)
        {
            foreach (var item in _Orders)
            {
                if (item.QRBlankOrder.Equals(Temp))
                {
                    return false;
                }
            }
            return true;
        }

        private bool FindedOrderCreditOrder(String[] ValidationDataMatrix, String QRBlankOrder)
        {
            try
            {
                ValidationDataMatrix[2] = ReplaceNumber(ValidationDataMatrix[2]);
                for (int i = 5; i < ValidationDataMatrix.Length; i++)
                {
                    if (SystemArgs.Request.CheckedOrder(ValidationDataMatrix[2], ValidationDataMatrix[i]) && SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[0].ID && SystemArgs.Request.CheckedExecutorWork(ValidationDataMatrix[2], ValidationDataMatrix[i], QRBlankOrder))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 1));
                    }
                    else if (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) >= SystemArgs.User.StatusesUser[1].ID && SystemArgs.Request.CheckedExecutorWork(ValidationDataMatrix[2], ValidationDataMatrix[i], QRBlankOrder))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 0));
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], -1));
                    }

                    if ((_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == -1).Count() == 0) && (_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == 0).Count() == 0))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = true;
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool FindedOrderBlankProvider(String[] ValidationDataMatrix, String QRBlankOrder)
        {
            try
            {
                ValidationDataMatrix[2] = ReplaceNumber(ValidationDataMatrix[2]);
                for (int i = 5; i < ValidationDataMatrix.Length; i++)
                {
                    if (SystemArgs.Request.CheckedOrder(ValidationDataMatrix[2], ValidationDataMatrix[i]) && (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[0].ID - 1 || SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[1].ID))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 1));
                    }
                    else if (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) >= SystemArgs.User.StatusesUser[0].ID)
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 0));
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], -1));
                    }

                    if ((_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == -1).Count() == 0) && (_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == 0).Count() == 0))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = true;
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool FindedOrderBlankOrder(String[] ValidationDataMatrix, String QRBlankOrder)
        {
            try
            {
                ValidationDataMatrix[2] = ReplaceNumber(ValidationDataMatrix[2]);

                for (int i = 5; i < ValidationDataMatrix.Length; i++)
                {
                    if (SystemArgs.Request.CheckedOrder(ValidationDataMatrix[2], ValidationDataMatrix[i]) && (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[0].ID - 1 || SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[1].ID))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 1));
                    }
                    else if (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) >= SystemArgs.User.StatusesUser[2].ID)
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 0));
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], -1));
                    }

                    if ((_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == -1).Count() == 0))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = true;
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool FindedBlankOrder_OPP(String[] ValidationDataMatrix, String QRBlankOrder)
        {
            try
            {
                ValidationDataMatrix[2] = ReplaceNumber(ValidationDataMatrix[2]);

                for (int i = 5; i < ValidationDataMatrix.Length; i++)
                {
                    if (SystemArgs.Request.FindedOrdersInAddBlankOrder(QRBlankOrder, ValidationDataMatrix[2], ValidationDataMatrix[i]))
                    {
                        if (SystemArgs.Request.CheckedOrder(ValidationDataMatrix[2], ValidationDataMatrix[i]) && SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) == SystemArgs.User.StatusesUser[0].ID - 1)
                        {
                            _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 1));
                        }
                        else if (SystemArgs.Request.CheckedStatusOrderDB(ValidationDataMatrix[2], ValidationDataMatrix[i]) > SystemArgs.User.StatusesUser[0].ID - 1)
                        {
                            _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], 0));
                        }
                        else
                        {
                            _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], -1));
                        }
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Add(new BlankOrderScanSession.NumberAndList(ValidationDataMatrix[2], ValidationDataMatrix[i], -1));
                    }

                    if ((_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == -1).Count() == 0) && (_BlankOrders[_BlankOrders.Count - 1].GetNumberAndLists().Where(p => p.Finded == 1).Count() > 0))
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = true;
                    }
                    else
                    {
                        _BlankOrders[_BlankOrders.Count - 1].Added = false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private String ReplaceNumber(String Number)
        {
            Number = Number.Remove(Number.IndexOf('-'), Number.Remove(0, Number.IndexOf('-') + 1).IndexOf('-') + 1);//Удаляю подстроку с шаблоном -*- отставляя полседнее -
            Number = Number.Replace('-', '(') + ")";//Заменяю - на скобочку ( и добавляю )
            return Number;
        }
    }
}
