﻿using System;
using SimpleTCP;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Views.KB
{
    public partial class KB_Scan_F : Form
    {
        public KB_Scan_F()
        {
            InitializeComponent();
        }
        private void Scan_F_Load(object sender, EventArgs e)
        {
            Scan_DGV.AutoGenerateColumns = false;
            Scan_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    SystemArgs.ScannerOrder.LoadResult += LoadToDGV;
                    break;
                case 1:
                    ViewWeb_PB.SizeMode = PictureBoxSizeMode.Zoom;
                    SystemArgs.WebcamScanOrder.LoadResult += LoadToDGV;
                    SystemArgs.WebcamScanOrder.LoadFrame += LoadFrame;
                    break;
                case 2:
                    SystemArgs.ServerMobileAppOrder.Load += LoadToDGV;
                    break;
            }
            EnableButton(false);
        }

        private void CheckedUnloading_TSM_Click(object sender, EventArgs e)
        {
            List<OrderScanSession> Temp = new List<OrderScanSession>();
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    Temp = SystemArgs.ScannerOrder.GetScanSessions();
                    break;
                case 1:
                    Temp = SystemArgs.WebcamScanOrder.GetScanSessions();
                    break;
                case 2:
                    Temp = SystemArgs.ServerMobileAppOrder.GetScanSessions();
                    break;
            }
            if (Temp.Count != 0)
            {
                try
                {
                    if (SystemArgs.UnLoadSpecific.SearchFileUnloading(Temp.Select(p => p.DataMatrix).ToList()))
                    {
                        if (SystemArgs.UnLoadSpecific.ExecutorMails.Count != 0)
                        {
                            KB_ScanUnloadSpecific Dialog = new KB_ScanUnloadSpecific();
                            Dialog.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("При проверки выгрузки не было найдено ни одного совпадения номера заказа с листом", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show("Файл был указан не верно или не хватило прав доступа к файлу", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SystemArgs.PrintLog(E.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Невозможно проверить выгрузку, нет данных", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CreateAct_TSM_Click(object sender, EventArgs e)
        {
            List<OrderScanSession> Temp = new List<OrderScanSession>();
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    Temp = SystemArgs.ScannerOrder.GetScanSessions();
                    break;
                case 1:
                    Temp = SystemArgs.WebcamScanOrder.GetScanSessions();
                    break;
                case 2:
                    Temp = SystemArgs.ServerMobileAppOrder.GetScanSessions();
                    break;
            }
            if (Temp.Count != 0)
            {
                if (SystemArgs.Excel.CreateAndExportActsKB(Temp))
                {
                    MessageBox.Show("Акты успешно сформированы и сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            else
            {
                MessageBox.Show("Невозможно сформировать акт, нет данных", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void KBScan_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
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
        private void ClosedServer()
        {
            switch (SystemArgs.SettingsUser.TypeScan)
            {
                case 0:
                    Status_TB.AppendText($"Закрытие сервера" + Environment.NewLine);
                    if (SystemArgs.ScannerOrder.Stop())
                    {
                        SystemArgs.ScannerOrder.LoadResult -= LoadToDGV;
                    }
                    break;
                case 1:
                    Status_TB.AppendText($"Выключение камеры" + Environment.NewLine);
                    if (SystemArgs.WebcamScanOrder.Stop())
                    {
                        SystemArgs.WebcamScanOrder.LoadResult -= LoadToDGV;
                        SystemArgs.WebcamScanOrder.LoadFrame -= LoadFrame;
                    }
                    break;
                case 2:
                    Status_TB.AppendText($"Закрытие сервера" + Environment.NewLine);
                    if (SystemArgs.ServerMobileAppOrder.Stop())
                    {
                        SystemArgs.ServerMobileAppOrder.Load -= LoadToDGV;
                    }
                    break;
            }
        }
        private void LoadFrame(Bitmap Frame)
        {
            if (ViewWeb_PB.Image != null)
            {
                ViewWeb_PB.Image = null;
            }

            ViewWeb_PB.Image = (Bitmap)Frame.Clone();
            Frame.Dispose();
        }

        private void LoadToDGV(List<OrderScanSession> ScanSessions)
        {
            Scan_DGV.Invoke((MethodInvoker)delegate ()
            {
                SessionCount_TB.Text = ScanSessions.Count().ToString();
                LoadStatusOperation(ScanSessions[ScanSessions.Count - 1].DataMatrix);
                Scan_DGV.Rows.Add();
                Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].DataMatrix;
                if (ScanSessions[ScanSessions.Count - 1].Unique == 2)
                {
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Обновление статуса";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Lime;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].Discription;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Lime;
                }
                else if (ScanSessions[ScanSessions.Count - 1].Unique==1)
                {
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Добавление";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.BlueViolet;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].Discription;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.BlueViolet;
                }
                else
                {
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Не уникален";
                    Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Red;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Value = ScanSessions[ScanSessions.Count - 1].Discription;
                    Scan_DGV[2, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Red;
                }
            });
        }
        private void LoadStatusOperation(String DataMatrix)
        {
            SpeechSynthesizer speechSynthesizerObj = new SpeechSynthesizer();
            speechSynthesizerObj.SpeakAsync($"{DataMatrix.Split('_')[1]}");
            Status_TB.AppendText(DataMatrix + Environment.NewLine);
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
                CreateAct_TSM.Enabled = true;
                CheckedUnloading_TSM.Enabled = true;
            }
            else
            {
                Add_B.Enabled = false;
                CreateAct_TSM.Enabled = false;
                CheckedUnloading_TSM.Enabled = false;
            }
        }
    }
}
