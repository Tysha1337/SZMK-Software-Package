using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using SZMK.Desktop.BindingModels;

namespace SZMK.Desktop.Views.Arhive
{
    public partial class AR_Decode_F : Form
    {
        public AR_Decode_F()
        {
            InitializeComponent();
        }
        public List<String> FileNames;
        private List<String> FailFileNames;
        private int FailCount = 0;
        private void Change_B_Click(object sender, EventArgs e)
        {
            OpenFileDialog Opd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите сканы чертежей",
                Filter = "TIF|*.tif|TIFF|*.tiff"
            };

            string date = DateTime.Now.ToString();
            date = date.Replace(".", "_").Replace(":", "_");

            if (Opd.ShowDialog() == DialogResult.OK)
            {
                if (Opd.FileName == String.Empty)
                {
                    return;
                }
                FailCount = 0;
                FailFileNames = new List<string>();
                DecodeFilesAsync(Opd);
            }
        }
        private async void DecodeFilesAsync(OpenFileDialog Opd)
        {
            EnableButton(false);
            await Task.Run(() => DecodeFiles(Opd));
        }
        private void DecodeFiles(OpenFileDialog Opd)
        {
            try
            {
                Directory.CreateDirectory("TempFile");
                Int32 CountFile = Opd.FileNames.Length;
                Int32 i = 0;
                foreach (String FileName in Opd.FileNames)
                {
                    Status_TB.Invoke((MethodInvoker)delegate ()
                    {
                        Status_TB.AppendText($"Файл" + Environment.NewLine + SystemArgs.Path.GetFileName(FileName) + Environment.NewLine + "обрабатывается, пожалуйста подождите..." + Environment.NewLine);
                        Status_TB.AppendText($">{i + 1}|{CountFile}<" + Environment.NewLine);
                        SystemArgs.PrintLog($"Файл" + SystemArgs.Path.GetFileName(FileName) + "обрабатывается, пожалуйста подождите...");
                        SystemArgs.PrintLog($">{i + 1}|{CountFile}<");
                    });

                    FileNames.Add(FileName);
                    SystemArgs.ByteScout.SendAndRead(SystemArgs.ByteScout.GetPathTempFile(FileName, i), FileName);
                    i++;
                }
                DeleteFilesAndDirectory();
                Status_TB.Invoke((MethodInvoker)delegate ()
                {
                    Status_TB.AppendText($"ОБРАБОТКА ЗАВЕРШЕНА!" + Environment.NewLine);
                    Status_TB.AppendText($">{i}|{CountFile}<" + Environment.NewLine);
                    SystemArgs.PrintLog($"ОБРАБОТКА ЗАВЕРШЕНА!");
                    SystemArgs.PrintLog($">{i}|{CountFile}<");
                });
                Change_B.Invoke((MethodInvoker)delegate ()
                {
                    EnableButton(true);
                });
                if (FailCount > 0)
                {
                    AR_NotDecode_F Dialog = new AR_NotDecode_F();
                    Dialog.DecodeFiles_TB.Text = (Opd.FileNames.Length - FailCount).ToString() + "/" + Opd.FileNames.Length.ToString();
                    foreach (String item in FailFileNames)
                    {
                        Dialog.Report_DGV.Rows.Add();
                        Dialog.Report_DGV[0, Dialog.Report_DGV.Rows.Count - 1].Value = item;
                    }
                    Dialog.ShowDialog();
                }
                if (SystemArgs.ByteScout.GetDecodeSession().Where(p => p.Unique==1).Count() == 0)
                {
                    Add_B.Invoke((MethodInvoker)delegate ()
                    {
                        Add_B.Enabled = false;
                    });
                }
            }
            catch(InvalidOperationException Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());
                return;
            }
            catch(Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());
                Add_B.Invoke((MethodInvoker)delegate ()
                {
                    Add_B.Enabled = true;
                });
                return;
            }
        }
        private void ARDecode_F_Load(object sender, EventArgs e)
        {
            FileNames = new List<string>();
            Scan_DGV.AutoGenerateColumns = false;
            Scan_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SystemArgs.ByteScout.Load += LoadToDGVAndTB;
            SystemArgs.ByteScout.Fail += StatusFailText;
            SystemArgs.ByteScout.NeedChecked = true;
            EnableButton(false);
            Change_B.Enabled = true;
        }

        private void Scan_DGV_SelectionChanged(object sender, EventArgs e)
        {
            Scan_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Scan_DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = Color.FromArgb(112, 238, 226);
            e.CellStyle.SelectionForeColor = Color.Black;
        }
        private bool DeleteFilesAndDirectory()
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo("TempFile");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                Directory.Delete("TempFile");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void StatusFailText(String Path)
        {
            Status_TB.Invoke((MethodInvoker)delegate ()
            {
                Status_TB.AppendText($"Файл {SystemArgs.Path.GetFileName(Path)} неправильный формат DataMatrix" + Environment.NewLine);
                SystemArgs.PrintLog($"Файл {SystemArgs.Path.GetFileName(Path)} неправильный формат DataMatrix");
                FailFileNames.Add(SystemArgs.Path.GetFileName(Path));
                FileNames.Remove(Path);
                FailCount++;
            });
        }
        private void LoadToDGVAndTB(List<DecodeScanSession> DecodeSession)
        {
                Status_TB.Invoke((MethodInvoker)delegate ()
                {
                    Status_TB.AppendText($"Получены данные" + Environment.NewLine + DecodeSession[DecodeSession.Count - 1].DataMatrix + Environment.NewLine);
                    SystemArgs.PrintLog($"Получены данные" + DecodeSession[DecodeSession.Count - 1].DataMatrix);
                });
                Scan_DGV.Invoke((MethodInvoker)delegate ()
                {
                    Scan_DGV.Rows.Add();
                    Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = DecodeSession[DecodeSession.Count - 1].DataMatrix;
                    if (DecodeSession[DecodeSession.Count - 1].Unique==1)
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Найден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Lime;
                    }
                    else if(DecodeSession[DecodeSession.Count - 1].Unique == 0)
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Уже подтвержден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = "Не найден";
                        Scan_DGV[1, Scan_DGV.Rows.Count - 1].Style.BackColor = Color.Red;
                    }
                });
        }

        private void CreateAct_TSM_Click(object sender, EventArgs e)
        {
            if (SystemArgs.ByteScout.GetDecodeSession().Count != 0)
            {
                if (SystemArgs.Excel.CreateAndExportActsArhive(SystemArgs.ByteScout.GetDecodeSession()))
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

        private void ARDecode_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                if (MessageBox.Show("Вы уверены, что хотите закрыть сканирование?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SystemArgs.ByteScout.Load -= LoadToDGVAndTB;
                    SystemArgs.ByteScout.Fail -= StatusFailText;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                SystemArgs.ByteScout.Load -= LoadToDGVAndTB;
                SystemArgs.ByteScout.Fail -= StatusFailText;
            }
        }
        private void EnableButton(Boolean flag)
        {
            if (flag)
            {
                Add_B.Enabled = true;
                Change_B.Enabled = true;
                CreateAct_TSM.Enabled = true;
            }
            else
            {
                Add_B.Enabled = false;
                Change_B.Enabled = false;
                CreateAct_TSM.Enabled = false;
            }
        }
    }
}
