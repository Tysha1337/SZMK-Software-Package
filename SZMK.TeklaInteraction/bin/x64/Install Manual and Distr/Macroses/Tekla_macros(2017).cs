// Generated by Tekla.Technology.Akit.ScriptBuilder
using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;


namespace Tekla.Technology.Akit.UserScript
{
    public class Script
    {
        public static void Run(Tekla.Technology.Akit.IScript akit)
        {
            try
            {
                if (Process.GetProcessesByName("SZMK.TeklaInteraction").Length == 0)
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    string system = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    string path = Path.GetPathRoot(system);
                    procInfo.FileName = path + @"SZMK\SZMK.TeklaInteraction\SZMK.Launcher.exe";
                    procInfo.WorkingDirectory = path + @"SZMK\SZMK.TeklaInteraction";
                    Process.Start(procInfo);
                }

                var client = new NamedPipeClientStream("Tekla2017");

                client.Connect(30000);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("�� ������� ����� ���������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException)
            {
                MessageBox.Show("������ ����������� � ��������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("�������������� ������, �������� � ������������" + Environment.NewLine + Ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}