using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.BindingModels;
using SZMK.Desktop.Services;

namespace SZMK.Desktop.Views.OPP
{
    public partial class OPP_Scan_F : Form
    {
        public OPP_Scan_F()
        {
            InitializeComponent();
        }

        private void OPPScan_F_Load(object sender, EventArgs e)
        {
            Scan_DGV.AutoGenerateColumns = false;
            Scan_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SystemArgs.UnLoadSpecific = new UnLoadSpecific();
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    SystemArgs.ScannerBlankOrder.LoadResult += LoadToDGV;
                    SystemArgs.ScannerBlankOrder.Status += LoadStatusOperation;
                    break;
                case 1:
                    ViewWeb_PB.SizeMode = PictureBoxSizeMode.Zoom;
                    SystemArgs.WebcamScanBlankOrder.LoadResult += LoadToDGV;
                    SystemArgs.WebcamScanBlankOrder.LoadFrame += LoadFrame;
                    SystemArgs.WebcamScanBlankOrder.Status += LoadStatusOperation;
                    break;
                case 2:
                    SystemArgs.ServerMobileAppBlankOrder.Load += LoadToDGV;
                    SystemArgs.ServerMobileAppBlankOrder.Status += LoadStatusOperation;
                    break;
            }
            EnableButton(false);
        }
        private void ClosedServer()
        {
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    Status_TB.AppendText($"Отключение сканера" + Environment.NewLine);
                    if (SystemArgs.ScannerBlankOrder.Stop())
                    {
                        SystemArgs.ScannerBlankOrder.LoadResult -= LoadToDGV;
                        SystemArgs.ScannerBlankOrder.Status -= LoadStatusOperation;
                    }
                    break;
                case 1:
                    Status_TB.AppendText($"Выключение камеры" + Environment.NewLine);
                    if (SystemArgs.WebcamScanBlankOrder.Stop())
                    {
                        SystemArgs.WebcamScanBlankOrder.LoadResult -= LoadToDGV;
                        SystemArgs.WebcamScanBlankOrder.LoadFrame -= LoadFrame;
                        SystemArgs.WebcamScanBlankOrder.Status -= LoadStatusOperation;
                    }
                    break;
                case 2:
                    Status_TB.AppendText($"Закрытие сервера" + Environment.NewLine);
                    if (SystemArgs.ServerMobileAppBlankOrder.Stop())
                    {
                        SystemArgs.ServerMobileAppBlankOrder.Load -= LoadToDGV;
                        SystemArgs.ServerMobileAppBlankOrder.Status -= LoadStatusOperation;
                    }
                    break;
            }
        }
        private void LoadToDGV(List<BlankOrderScanSession> ScanSessions)
        {
            Scan_DGV.Invoke((MethodInvoker)delegate ()
            {
                SessionCount_TB.Text = ScanSessions.Count().ToString();
                Scan_DGV.Rows.Add();
                if (ScanSessions[ScanSessions.Count - 1].Added)
                {
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].QRBlankOrder;
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Lime;
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "QR бланка заказа";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.AliceBlue;
                }
                else if (ScanSessions[ScanSessions.Count - 1].GetNumberAndLists().Where(p => p.Finded == -1).Count() == 0)
                {
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].QRBlankOrder;
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Orange;
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "QR бланка заказа";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.AliceBlue;
                }
                else
                {
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].QRBlankOrder;
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Red;
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "QR бланка заказа";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.AliceBlue;
                }
                foreach (BlankOrderScanSession.NumberAndList Order in ScanSessions[ScanSessions.Count - 1].GetNumberAndLists())
                {
                    Scan_DGV.Rows.Add();
                    String TextOrder = "Заказ №" + Order.Number + " Лист №" + Order.List.ToString();
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = TextOrder;
                    if (Order.Finded == 1)
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Найден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Lime;
                    }
                    else if (Order.Finded == 0)
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Уже подтвержден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Не найден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Red;
                    }
                }
            });
        }
        private void LoadFrame(Bitmap Frame)
        {
           ViewWeb_PB.Image = Frame;
        }
        private void LoadStatusOperation(String DataMatrix)
        {
            Status_TB.Invoke((MethodInvoker)delegate ()
            {
                if (DataMatrix.Split('_').Length >= 4)
                {
                    SpeechSynthesizer speechSynthesizerObj = new SpeechSynthesizer();
                    speechSynthesizerObj.SpeakAsync($"{DataMatrix.Split('_')[1]}");
                }
                Status_TB.AppendText("Получен: " + DataMatrix + Environment.NewLine);
            });
        }

        private void OPPScan_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("Вы уверены, что хотите закрыть сканирование?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClosedServer();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                ClosedServer();
            }
        }

        private void Scan_DGV_SelectionChanged(object sender, EventArgs e)
        {
            Scan_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (Scan_DGV.Rows.Count > 0)
            {
                EnableButton(true);
            }
            else
            {
                EnableButton(false);
            }
        }

        private void Scan_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(112, 238, 226);
            e.CellStyle.SelectionForeColor = Color.Black;
        }
        private void EnableButton(Boolean flag)
        {
            if (flag)
            {
                Add_B.Enabled = true;
            }
            else
            {
                Add_B.Enabled = false;
            }
        }
    }
}
