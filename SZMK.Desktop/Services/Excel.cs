using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;
using OfficeOpenXml.Table.PivotTable;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Models;

namespace SZMK.Desktop.Services
{
    /*Класс для работы с Excel файлами в нем реализуется создание актов по итогу сканирования, а также отчетов*/
    public class Excel
    {
        public Boolean CreateAndExportActsKB(List<OrderScanSession> ScanSession)
        {
            SaveFileDialog SaveAct = new SaveFileDialog();
            String date = DateTime.Now.ToString();
            date = date.Replace(".", "_");
            date = date.Replace(":", "_");
            SaveAct.FileName = "Акты от " + date;
            FileInfo fInfoSrcUnique = new FileInfo(SystemArgs.Path.TemplateActUniquePath);
            FileInfo fInfoSrcNoUnique = new FileInfo(SystemArgs.Path.TemplateActNoUniquePath);
            String Status = (from p in SystemArgs.Statuses
                             where p.IDPosition == SystemArgs.User.GetPosition().ID
                             select p.Name).Single();

            if (SaveAct.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String UniqueFileName = "";
                    String NoUniqueFileName = "";

                    UniqueFileName = SaveAct.FileName + @"\Акт от " + date + " уникальных чертежей.xlsx";
                    NoUniqueFileName = SaveAct.FileName + @"\Акт от " + date + " не уникальных чертежей.xlsx";

                    Directory.CreateDirectory(SaveAct.FileName.Replace(".xlsx", ""));
                    new ExcelPackage(fInfoSrcUnique).File.CopyTo(UniqueFileName);
                    new ExcelPackage(fInfoSrcNoUnique).File.CopyTo(NoUniqueFileName);

                    ExcelPackage wbUnique = new ExcelPackage(new System.IO.FileInfo(UniqueFileName));
                    ExcelWorksheet wsUnique = wbUnique.Workbook.Worksheets[1];

                    ExcelPackage wbNoUnique = new ExcelPackage(new System.IO.FileInfo(NoUniqueFileName));
                    ExcelWorksheet wsNoUnique = wbNoUnique.Workbook.Worksheets[1];

                    if (SaveAct.FileName.IndexOf(@":\") != -1)
                    {
                        for (Int32 i = 0; i < ScanSession.Count; i++)
                        {
                            String[] SplitDataMatrix = ScanSession[i].DataMatrix.Split('_');
                            if (ScanSession[i].Unique != 0)
                            {
                                int rowCntActUnique = wsUnique.Dimension.End.Row;
                                wsUnique.Cells[rowCntActUnique + 1, 1].Value = SplitDataMatrix[0];
                                wsUnique.Cells[rowCntActUnique + 1, 2].Value = SplitDataMatrix[1];
                                wsUnique.Cells[rowCntActUnique + 1, 3].Value = SplitDataMatrix[2];
                                wsUnique.Cells[rowCntActUnique + 1, 4].Value = SplitDataMatrix[3];
                                wsUnique.Cells[rowCntActUnique + 1, 5].Value = Convert.ToDouble(SplitDataMatrix[4]);
                                wsUnique.Cells[rowCntActUnique + 1, 6].Value = Convert.ToDouble(SplitDataMatrix[5]);
                                wsUnique.Cells[rowCntActUnique + 1, 7].Value = DateTime.Now.ToString();
                                wsUnique.Cells[rowCntActUnique + 1, 8].Value = Status;
                                wsUnique.Cells[rowCntActUnique + 1, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                            }
                            else
                            {
                                int rowCntActNoUnique = wsNoUnique.Dimension.End.Row;
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 1].Value = SplitDataMatrix[0];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 2].Value = SplitDataMatrix[1];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 3].Value = SplitDataMatrix[2];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 4].Value = SplitDataMatrix[3];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 5].Value = Convert.ToDouble(SplitDataMatrix[4]);
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 6].Value = Convert.ToDouble(SplitDataMatrix[5]);
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 7].Value = DateTime.Now.ToString();
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 8].Value = Status;
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                            }
                        }
                        int lastline = wsUnique.Dimension.End.Row;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells[lastline + 2, 6].Value = "Принял";
                        wsUnique.Cells[lastline + 3, 6].Value = "Сдал";
                        wsUnique.Cells[lastline + 2, 8].Value = "______________";
                        wsUnique.Cells[lastline + 3, 8].Value = "______________";
                        wsUnique.Cells[lastline + 2, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                        wsUnique.Cells[lastline + 3, 9].Value = "/______________/";
                        wbUnique.Save();
                        lastline = wsNoUnique.Dimension.End.Row;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells[lastline + 2, 6].Value = "Принял";
                        wsNoUnique.Cells[lastline + 3, 6].Value = "Сдал";
                        wsNoUnique.Cells[lastline + 2, 8].Value = "______________";
                        wsNoUnique.Cells[lastline + 3, 8].Value = "______________";
                        wsNoUnique.Cells[lastline + 2, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                        wsNoUnique.Cells[lastline + 3, 9].Value = "/______________/";
                        wbNoUnique.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (File.Exists(SaveAct.FileName))
                    {
                        Process.Start(SaveAct.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CreateAndExportActsArhive(List<DecodeScanSession> ScanSession)
        {
            SaveFileDialog SaveAct = new SaveFileDialog();
            String date = DateTime.Now.ToString();
            date = date.Replace(".", "_");
            date = date.Replace(":", "_");
            SaveAct.FileName = "Акты от " + date;
            FileInfo fInfoSrcUnique = new FileInfo(SystemArgs.Path.TemplateActUniquePath);
            FileInfo fInfoSrcNoUnique = new FileInfo(SystemArgs.Path.TemplateActNoUniquePath);
            String Status = (from p in SystemArgs.Statuses
                             where p.IDPosition == SystemArgs.User.GetPosition().ID
                             select p.Name).Single();

            if (SaveAct.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String UniqueFileName = "";
                    String NoUniqueFileName = "";

                    UniqueFileName = SaveAct.FileName + @"\Акт от " + date + " найденных чертежей.xlsx";
                    NoUniqueFileName = SaveAct.FileName + @"\Акт от " + date + " не найденных чертежей.xlsx";

                    Directory.CreateDirectory(SaveAct.FileName.Replace(".xlsx", ""));
                    new ExcelPackage(fInfoSrcUnique).File.CopyTo(UniqueFileName);
                    new ExcelPackage(fInfoSrcNoUnique).File.CopyTo(NoUniqueFileName);

                    ExcelPackage wbUnique = new ExcelPackage(new System.IO.FileInfo(UniqueFileName));
                    ExcelWorksheet wsUnique = wbUnique.Workbook.Worksheets[1];

                    ExcelPackage wbNoUnique = new ExcelPackage(new System.IO.FileInfo(NoUniqueFileName));
                    ExcelWorksheet wsNoUnique = wbNoUnique.Workbook.Worksheets[1];

                    if (SaveAct.FileName.IndexOf(@":\") != -1)
                    {
                        wsUnique.Cells[1, 1].Value = "Акт найденных чертежей";
                        wsNoUnique.Cells[1, 1].Value = "Акт не найденных чертежей";
                        for (Int32 i = 0; i < ScanSession.Count; i++)
                        {
                            String[] SplitDataMatrix = ScanSession[i].DataMatrix.Split('_');
                            if (ScanSession[i].Unique == 1 || ScanSession[i].Unique == 0)
                            {
                                int rowCntActUnique = wsUnique.Dimension.End.Row;
                                wsUnique.Cells[rowCntActUnique + 1, 1].Value = SplitDataMatrix[0];
                                wsUnique.Cells[rowCntActUnique + 1, 2].Value = SplitDataMatrix[1];
                                wsUnique.Cells[rowCntActUnique + 1, 3].Value = SplitDataMatrix[2];
                                wsUnique.Cells[rowCntActUnique + 1, 4].Value = SplitDataMatrix[3];
                                wsUnique.Cells[rowCntActUnique + 1, 5].Value = Convert.ToDouble(SplitDataMatrix[4]);
                                wsUnique.Cells[rowCntActUnique + 1, 6].Value = Convert.ToDouble(SplitDataMatrix[5]);
                                wsUnique.Cells[rowCntActUnique + 1, 7].Value = DateTime.Now.ToString();
                                wsUnique.Cells[rowCntActUnique + 1, 8].Value = Status;
                                wsUnique.Cells[rowCntActUnique + 1, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                            }
                            else
                            {
                                int rowCntActNoUnique = wsNoUnique.Dimension.End.Row;
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 1].Value = SplitDataMatrix[0];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 2].Value = SplitDataMatrix[1];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 3].Value = SplitDataMatrix[2];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 4].Value = SplitDataMatrix[3];
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 5].Value = Convert.ToDouble(SplitDataMatrix[4]);
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 6].Value = Convert.ToDouble(SplitDataMatrix[5]);
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 7].Value = DateTime.Now.ToString();
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 8].Value = Status;
                                wsNoUnique.Cells[rowCntActNoUnique + 1, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                            }
                        }
                        int lastline = wsUnique.Dimension.End.Row;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells["A2:I" + lastline].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        wsUnique.Cells[lastline + 2, 6].Value = "Принял";
                        wsUnique.Cells[lastline + 3, 6].Value = "Сдал";
                        wsUnique.Cells[lastline + 2, 8].Value = "______________";
                        wsUnique.Cells[lastline + 3, 8].Value = "______________";
                        wsUnique.Cells[lastline + 2, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                        wsUnique.Cells[lastline + 3, 9].Value = "/______________/";
                        wbUnique.Save();
                        lastline = wsNoUnique.Dimension.End.Row;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells["A2:I" + lastline].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        wsNoUnique.Cells[lastline + 2, 6].Value = "Принял";
                        wsNoUnique.Cells[lastline + 3, 6].Value = "Сдал";
                        wsNoUnique.Cells[lastline + 2, 8].Value = "______________";
                        wsNoUnique.Cells[lastline + 3, 8].Value = "______________";
                        wsNoUnique.Cells[lastline + 2, 9].Value = SystemArgs.User.Surname + " " + SystemArgs.User.Name + " " + SystemArgs.User.MiddleName;
                        wsNoUnique.Cells[lastline + 3, 9].Value = "/______________/";
                        wbNoUnique.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (File.Exists(SaveAct.FileName))
                    {
                        Process.Start(SaveAct.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReportOrderOfDate(DateTime First, DateTime Second)
        {
            SaveFileDialog SaveReport = new SaveFileDialog();
            String date = DateTime.Now.ToString();
            date = date.Replace(".", "_");
            date = date.Replace(":", "_");
            SaveReport.FileName = "Отчет за выбранный период от " + date;
            SaveReport.Filter = "Excel Files .xlsx|*.xlsx";

            System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(SystemArgs.Path.TemplateReportOrderOfDatePath);

            if (SaveReport.ShowDialog() == DialogResult.OK)
            {
                var WBcopy = new ExcelPackage(fInfoSrcUnique).File.CopyTo(SaveReport.FileName);

                try
                {
                    ExcelPackage WB = new ExcelPackage(new System.IO.FileInfo(SaveReport.FileName));
                    ExcelWorksheet WS = WB.Workbook.Worksheets[1];
                    var rowCntReport = WS.Dimension.End.Row;

                    if (SaveReport.FileName.IndexOf(@":\") != -1)
                    {
                        List<Order> Report = SystemArgs.Orders.Where(p => (p.DateCreate >= First) && (p.DateCreate <= Second.AddSeconds(86399))).ToList();
                        for (Int32 i = 0; i < Report.Count; i++)
                        {
                            List<StatusOfOrder> OrderStatuses = (from p in SystemArgs.StatusOfOrders
                                                                 where p.IDOrder == Report[i].ID
                                                                 orderby p.DateCreate
                                                                 select p).ToList();
                            WS.Cells[i + rowCntReport + 1, 1].Value = Report[i].Number;
                            String[] NubmerOrder = Report[i].BlankOrder.QR.Split('_');

                            if (NubmerOrder.Length > 1)
                            {
                                Regex regex = new Regex(@"\d*-\d*-\d*");
                                MatchCollection matches = regex.Matches(NubmerOrder[1]);
                                if (matches.Count > 0)
                                {
                                    WS.Cells[i + rowCntReport + 1, 2].Value = NubmerOrder[1];
                                }
                                else
                                {
                                    WS.Cells[i + rowCntReport + 1, 2].Value = NubmerOrder[2];
                                }
                            }
                            else
                            {
                                WS.Cells[i + rowCntReport + 1, 2].Value = Report[i].BlankOrder.QR;
                            }
                            WS.Cells[i + rowCntReport + 1, 3].Value = Report[i].List;
                            WS.Cells[i + rowCntReport + 1, 4].Value = Report[i].Mark;
                            WS.Cells[i + rowCntReport + 1, 5].Value = Report[i].Executor;
                            WS.Cells[i + rowCntReport + 1, 6].Value = Report[i].Lenght.ToString();
                            WS.Cells[i + rowCntReport + 1, 7].Value = Report[i].Weight.ToString();
                            WS.Cells[i + rowCntReport + 1, 8].Value = Report[i].Status.Name;
                            Int32 Count = 0;
                            for (int j = 0; j < OrderStatuses.Count; j++)
                            {
                                User Temp = (from p in SystemArgs.Users
                                             where p.ID == OrderStatuses[j].IDUser
                                             select p).Single();
                                if (j < 3 || OrderStatuses.Count == 4 || j == OrderStatuses.Count - 1)
                                {
                                    WS.Cells[i + rowCntReport + 1, 9 + Count].Value = Temp.Surname + " " + Temp.Name.First() + ". " + Temp.MiddleName.First() + ".";
                                    WS.Cells[i + rowCntReport + 1, 10 + Count].Value = OrderStatuses[j].DateCreate.ToString();
                                    Count += 2;
                                }
                            }
                        }
                        int last = WS.Dimension.End.Row;
                        Double Sum = Report.Sum(p => p.Weight);
                        WS.Cells[last + 1, 1].Value = "Итого";
                        WS.Cells[last + 1, 7].Value = Sum;
                        last = WS.Dimension.End.Row;
                        WS.Cells["A2:P" + last].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + WS.Dimension.End.Row.ToString()].AutoFitColumns();
                        WS.Cells["A2:P" + WS.Dimension.End.Row.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        WB.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (File.Exists(SaveReport.FileName))
                    {
                        Process.Start(SaveReport.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReportOrderOfSelect(List<Order> Report)
        {
            SaveFileDialog SaveReport = new SaveFileDialog();
            String date = DateTime.Now.ToString();
            date = date.Replace(".", "_");
            date = date.Replace(":", "_");
            SaveReport.FileName = "Отчет за выбранный период от " + date;
            SaveReport.Filter = "Excel Files .xlsx|*.xlsx";

            System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(SystemArgs.Path.TemplateReportOrderOfDatePath);

            if (SaveReport.ShowDialog() == DialogResult.OK)
            {
                var WBcopy = new ExcelPackage(fInfoSrcUnique).File.CopyTo(SaveReport.FileName);

                try
                {
                    ExcelPackage WB = new ExcelPackage(new System.IO.FileInfo(SaveReport.FileName));
                    ExcelWorksheet WS = WB.Workbook.Worksheets[1];
                    var rowCntReport = WS.Dimension.End.Row;

                    if (SaveReport.FileName.IndexOf(@":\") != -1)
                    {
                        for (Int32 i = 0; i < Report.Count; i++)
                        {
                            List<StatusOfOrder> OrderStatuses = (from p in SystemArgs.StatusOfOrders
                                                                 where p.IDOrder == Report[i].ID
                                                                 orderby p.DateCreate
                                                                 select p).ToList();
                            WS.Cells[i + rowCntReport + 1, 1].Value = Report[i].Number;
                            String[] NubmerOrder = Report[i].BlankOrder.QR.Split('_');

                            if (NubmerOrder.Length > 1)
                            {
                                Regex regex = new Regex(@"\d*-\d*-\d*");
                                MatchCollection matches = regex.Matches(NubmerOrder[1]);
                                if (matches.Count > 0)
                                {
                                    WS.Cells[i + rowCntReport + 1, 2].Value = NubmerOrder[1];
                                }
                                else
                                {
                                    WS.Cells[i + rowCntReport + 1, 2].Value = NubmerOrder[2];
                                }
                            }
                            else
                            {
                                WS.Cells[i + rowCntReport + 1, 2].Value = Report[i].BlankOrder.QR;
                            }
                            WS.Cells[i + rowCntReport + 1, 3].Value = Report[i].List;
                            WS.Cells[i + rowCntReport + 1, 4].Value = Report[i].Mark;
                            WS.Cells[i + rowCntReport + 1, 5].Value = Report[i].Executor;
                            WS.Cells[i + rowCntReport + 1, 6].Value = Report[i].Lenght.ToString();
                            WS.Cells[i + rowCntReport + 1, 7].Value = Report[i].Weight.ToString();
                            WS.Cells[i + rowCntReport + 1, 8].Value = Report[i].Status.Name;
                            Int32 Count = 0;
                            for (int j = 0; j < OrderStatuses.Count; j++)
                            {
                                User Temp = (from p in SystemArgs.Users
                                             where p.ID == OrderStatuses[j].IDUser
                                             select p).Single();
                                if (j < 3 || OrderStatuses.Count == 4 || j == OrderStatuses.Count - 1)
                                {
                                    WS.Cells[i + rowCntReport + 1, 9 + Count].Value = Temp.Surname + " " + Temp.Name.First() + ". " + Temp.MiddleName.First() + ".";
                                    WS.Cells[i + rowCntReport + 1, 10 + Count].Value = OrderStatuses[j].DateCreate.ToString();
                                    Count += 2;
                                }
                            }
                        }
                        int last = WS.Dimension.End.Row;
                        Double Sum = Report.Sum(p => p.Weight);
                        WS.Cells[last + 1, 1].Value = "Итого";
                        WS.Cells[last + 1, 7].Value = Sum;
                        last = WS.Dimension.End.Row;
                        WS.Cells["A2:P" + last].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + last].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        WS.Cells["A2:P" + WS.Dimension.End.Row.ToString()].AutoFitColumns();
                        WS.Cells["A2:P" + WS.Dimension.End.Row.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        WB.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (MessageBox.Show("Отчет сформирован успешно." + Environment.NewLine + "Открыть его?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (File.Exists(SaveReport.FileName))
                    {
                        Process.Start(SaveReport.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Отчет по пути не обнаружен." + Environment.NewLine + "Ошибка открытия отчета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        struct TimeOrder
        {
            public Int64 _StatusID;
            public List<Double> Times;

            public TimeOrder(Int64 StatusID)
            {
                _StatusID = StatusID;
                Times = new List<Double>();
            }
        }
        public Boolean ReportPastTimeofDate(List<StatusOfOrder> Report, String FileName)
        {

            System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(SystemArgs.Path.TemplateReportPastTimeofDate);
            var WBcopy = new ExcelPackage(fInfoSrcUnique).File.CopyTo(FileName);

            try
            {
                ExcelPackage WB = new ExcelPackage(new System.IO.FileInfo(FileName));
                ExcelWorksheet WS = WB.Workbook.Worksheets[1];
                var rowCntReport = WS.Dimension.End.Row;

                if (FileName.IndexOf(@":\") != -1)
                {
                    var GroupByOrder = Report.GroupBy(p => p.IDOrder);
                    List<TimeOrder> TimeOrdersUnclean = new List<TimeOrder>();
                    List<TimeOrder> TimeOrdersClean = new List<TimeOrder>();
                    List<Order> Temp = new List<Order>();
                    foreach (var key in GroupByOrder)
                    {
                        Temp.Add(SystemArgs.Orders.Where(p => p.ID == key.Key).Single());
                    }

                    for (int j = 1; j < SystemArgs.Statuses.Count + 1; j++)
                    {
                        if (j == SystemArgs.Statuses.Count || j < 4)
                        {
                            TimeOrdersClean.Add(new TimeOrder(j));

                            TimeOrdersUnclean.Add(new TimeOrder(j));

                            Double[] Data = new Double[4];

                            Data[0] = Temp.Where(p => p.Status.ID > j).Sum(p => p.Weight);
                            Data[1] = Temp.Where(p => p.Status.ID == j).Sum(p => p.Weight);
                            Data[2] = Temp.Where(p => p.Status.ID > j).Count();
                            Data[3] = Temp.Where(p => p.Status.ID == j).Count();

                            foreach (var key in GroupByOrder)
                            {
                                if (key.Count() > j)
                                {
                                    List<DateTime> TimesFirst = key.Where(p => p.IDStatus == j).Select(p => p.DateCreate).ToList();
                                    List<DateTime> TimesSecond = new List<DateTime>();
                                    if (j == 3)
                                    {
                                        TimesSecond = key.Where(p => p.IDStatus == j + 3).Select(p => p.DateCreate).ToList();
                                    }
                                    else
                                    {
                                        TimesSecond = key.Where(p => p.IDStatus == j + 1).Select(p => p.DateCreate).ToList();
                                    }

                                    if (TimesFirst.Count() == 1 && TimesSecond.Count() == 1)
                                    {
                                        Double Start = (TimesFirst[0] - TimesFirst[0].Date.AddHours(8)).TotalHours;
                                        Double End = (TimesSecond[0] - TimesSecond[0].Date.AddHours(8)).TotalHours;

                                        Int32 WorkDay = 0;
                                        Int32 Weekend = 0;

                                        if (TimesFirst[0].Date != TimesSecond[0].Date)
                                        {
                                            for (int d = 0; d < (TimesSecond[0].Date - TimesFirst[0].Date).TotalDays; d++)
                                            {
                                                if (TimesFirst[0].AddDays(d + 1).DayOfWeek != DayOfWeek.Saturday && TimesFirst[0].AddDays(d + 1).DayOfWeek != DayOfWeek.Sunday)
                                                {
                                                    WorkDay++;
                                                }
                                                else
                                                {
                                                    Weekend++;
                                                }
                                            }
                                        }

                                        TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Add((TimesSecond[0] - TimesFirst[0].AddDays(Weekend)).TotalHours);

                                        if (Start < 0)
                                        {
                                            Start = Math.Ceiling(-Start);
                                        }
                                        else if (Start > 9)
                                        {
                                            Start = Math.Ceiling(Start);
                                        }

                                        if (End < 0)
                                        {
                                            End = Math.Ceiling(-End);
                                        }
                                        else if (End > 9)
                                        {
                                            End = Math.Ceiling(End);
                                        }
                                        TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Add(End - Start + WorkDay * 9);

                                    }
                                }

                                if (j == SystemArgs.Statuses.Count)
                                {
                                    WS.Cells[2, j - 1].Value = Data[0];
                                    WS.Cells[3, j - 1].Value = Data[1];
                                    WS.Cells[4, j - 1].Value = Data[2];
                                    WS.Cells[5, j - 1].Value = Data[3];
                                }
                                else
                                {
                                    WS.Cells[2, j + 1].Value = Data[0];
                                    WS.Cells[3, j + 1].Value = Data[1];
                                    WS.Cells[4, j + 1].Value = Data[2];
                                    WS.Cells[5, j + 1].Value = Data[3];
                                }

                                if (TimeOrdersUnclean.Count != 0 && TimeOrdersClean.Count != 0)
                                {
                                    if (TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Count != 0 && TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Count != 0)
                                    {
                                        Int32 UncleanHour = Convert.ToInt32(Math.Truncate(TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Sum() / TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Count));
                                        Int32 UncleanMin = Convert.ToInt32((TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Sum() / TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Count - Math.Truncate(TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Sum() / TimeOrdersUnclean[TimeOrdersUnclean.Count - 1].Times.Count)) * 60);

                                        Int32 CleanHour = Convert.ToInt32(Math.Truncate(TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Sum() / TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Count));
                                        Int32 CleanMin = Convert.ToInt32((TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Sum() / TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Count - Math.Truncate(TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Sum() / TimeOrdersClean[TimeOrdersClean.Count - 1].Times.Count)) * 60);

                                        if (j == SystemArgs.Statuses.Count)
                                        {
                                            if (UncleanHour != 0)
                                            {
                                                WS.Cells[6, j - 1].Value = $"{UncleanHour} ч {UncleanMin} мин";
                                            }
                                            else
                                            {
                                                WS.Cells[6, j - 1].Value = $"{UncleanMin} мин";
                                            }
                                            if (CleanHour != 0)
                                            {
                                                WS.Cells[7, j - 1].Value = $"{CleanHour} ч {CleanMin} мин";
                                            }
                                            else
                                            {
                                                WS.Cells[7, j - 1].Value = $"{CleanMin} мин";
                                            }
                                        }
                                        else
                                        {
                                            if (UncleanHour != 0)
                                            {
                                                WS.Cells[6, j + 1].Value = $"{UncleanHour} ч {UncleanMin} мин";
                                            }
                                            else
                                            {
                                                WS.Cells[6, j + 1].Value = $"{UncleanMin} мин";
                                            }
                                            if (CleanHour != 0)
                                            {
                                                WS.Cells[7, j + 1].Value = $"{CleanHour} ч {CleanMin} мин";
                                            }
                                            else
                                            {
                                                WS.Cells[7, j + 1].Value = $"{CleanMin} мин";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    WB.Save();
                }
            }
            catch (Exception e)
            {
                SystemArgs.PrintLog(e.ToString());
                return false;
            }
            return true;
        }
        public bool ReportSteelOfDate(List<Order> Report, String FileName)
        {
            System.IO.FileInfo fInfoSrcUnique = new System.IO.FileInfo(SystemArgs.Path.TemplateReportSteel);
            var WBcopy = new ExcelPackage(fInfoSrcUnique).File.CopyTo(FileName);

            try
            {
                ExcelPackage WB = new ExcelPackage(new System.IO.FileInfo(FileName));
                ExcelWorksheet WS = WB.Workbook.Worksheets[1];
                var rowCntReport = WS.Dimension.End.Row;

                if (FileName.IndexOf(@":\") != -1)
                {
                    List<Detail> details = new List<Detail>();
                    for (int i = 0; i < Report.Count; i++)
                    {
                        details.AddRange(SystemArgs.Request.GetDetails(Report[i].ID));
                    }

                    var GroupByOrder = details.GroupBy(p => p.MarkSteel).Select(p => new { Mark = p.Key, Profile = p.GroupBy(l => l.Profile) });
                    foreach (var key in GroupByOrder)
                    {
                        foreach (var item in key.Profile)
                        {
                            rowCntReport = WS.Dimension.End.Row;
                            WS.Cells[rowCntReport + 1, 2].Value = key.Mark;
                            WS.Cells[rowCntReport + 1, 3].Value = item.Key;
                            WS.Cells[rowCntReport + 1, 4].Value = item.Sum(p => p.SubtotalWeight);
                        }
                    }
                    int last = WS.Dimension.End.Row;

                    WS.Cells[last + 1, 3].Value = "Итого";
                    WS.Cells[last + 1, 4].Value = details.Sum(p => p.SubtotalWeight);

                    last = WS.Dimension.End.Row;

                    WS.Cells["B2:D" + last].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    WS.Cells["B2:D" + last].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    WS.Cells["B2:D" + last].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    WS.Cells["B2:D" + last].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    WS.Cells["B2:D" + last].Style.Font.Name = "Times New Roman";
                    WS.Cells["B2:D" + last].Style.Font.Size = 14;
                    WS.Cells["B2:D" + last].AutoFitColumns();
                    WS.Cells["B2:D" + last].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    WB.Save();
                }
            }
            catch (Exception e)
            {
                SystemArgs.PrintLog(e.ToString());
                return false;
            }
            return true;
        }
    }
}
