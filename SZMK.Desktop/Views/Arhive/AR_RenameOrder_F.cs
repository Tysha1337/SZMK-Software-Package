using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Views.Arhive
{
    public partial class AR_RenameOrder_F : Form
    {
        public AR_RenameOrder_F()
        {
            InitializeComponent();
        }
        public List<String> FileNames;
        private List<String> FailFileNames;
        public List<String> DecodeNames;
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
                    });

                    FileNames.Add(FileName);
                    DecodeNames.Add(SystemArgs.ByteScout.SendAndRead(SystemArgs.ByteScout.GetPathTempFile(FileName, i), FileName));
                    if (DecodeNames[DecodeNames.Count - 1].Split('_').Length != 6)
                    {
                        DecodeNames.Remove(DecodeNames[DecodeNames.Count - 1]);
                    }
                    i++;
                }
                DeleteFilesAndDirectory();
                Status_TB.Invoke((MethodInvoker)delegate ()
                {
                    Status_TB.AppendText($"ОБРАБОТКА ЗАВЕРШЕНА!" + Environment.NewLine);
                    Status_TB.AppendText($">{i}|{CountFile}<" + Environment.NewLine);
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
                if (DecodeNames.Count == 0)
                {
                    Save_B.Invoke((MethodInvoker)delegate ()
                    {
                        Save_B.Enabled = false;
                    });
                }
            }
            catch (InvalidOperationException)
            {
                return;
            }
            catch (Exception e)
            {
                SystemArgs.PrintLog(e.ToString());
                MessageBox.Show(e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Save_B.Invoke((MethodInvoker)delegate ()
                {
                    Save_B.Enabled = true;
                });
                return;
            }
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
                FailFileNames.Add(SystemArgs.Path.GetFileName(Path));
                FileNames.Remove(Path);
                FailCount++;
            });
        }
        private void LoadToDGVAndTB(String result,String Path)
        {
            Status_TB.Invoke((MethodInvoker)delegate ()
            {
                Status_TB.AppendText($"Получены данные" + Environment.NewLine + result + Environment.NewLine);
            });
            Scan_DGV.Invoke((MethodInvoker)delegate ()
            {
                Scan_DGV.Rows.Add();
                Scan_DGV[0, Scan_DGV.Rows.Count - 1].Value = result;
                Scan_DGV[1, Scan_DGV.Rows.Count - 1].Value = SystemArgs.Path.GetFileName(Path);
            });
        }
        private void EnableButton(Boolean flag)
        {
            if (flag)
            {
                Save_B.Enabled = true;
                Change_B.Enabled = true;
            }
            else
            {
                Save_B.Enabled = false;
                Change_B.Enabled = false;
            }
        }

        private void ARRenameOrder_Load(object sender, EventArgs e)
        {
            FileNames = new List<string>();
            DecodeNames = new List<string>();
            Scan_DGV.AutoGenerateColumns = false;
            Scan_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SystemArgs.ByteScout.Rename += LoadToDGVAndTB;
            SystemArgs.ByteScout.Fail += StatusFailText;
            SystemArgs.ByteScout.NeedChecked = false;
            EnableButton(false);
            Change_B.Enabled = true;
        }

        private void ARRenameOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemArgs.ByteScout.Rename -= LoadToDGVAndTB;
            SystemArgs.ByteScout.Fail -= StatusFailText;
        }
    }
}
