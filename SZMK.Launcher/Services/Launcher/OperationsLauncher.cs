using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Launcher.Views;

namespace SZMK.Launcher.Services.Launcher
{
    public class OperationsLauncher : BaseService
    {
        private readonly Logger logger;
        private Main notify;

        public OperationsLauncher(Main notify)
        {
            logger = LogManager.GetCurrentClassLogger();
            this.notify = notify;
        }
        public void DeleteLogAndTemp()
        {
            try
            {
                DeleteLogs();
                DeleteTemp();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void DeleteLogs()
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Logs"))
                {
                    notify.Notify(0, "Начато удаление логов");
                    List<string> files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Logs").ToList();
                    notify.SetMaximum(files.Count);
                    for (int i = 0; i < files.Count; i++)
                    {
                        DateTime create = Directory.GetCreationTime(files[i]);
                        if (create < DateTime.Now.AddDays(-30))
                        {
                            File.Delete(files[i]);
                        }
                        notify.Notify(i + 1, $"Удалено {i + 1} из {files.Count}");
                    }
                    notify.Notify(files.Count, "Удаление логов завершено успешно");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void DeleteTemp()
        {
            try
            {
                notify.Notify(0, "Начато удаление старого обновления");
                notify.SetMaximum(1);
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Temp"))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + @"\Temp", true);
                }
                if (File.Exists(Directory.GetCurrentDirectory() + @"\InfoProduct.conf"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"\InfoProduct.conf");
                }
                if (File.Exists(Directory.GetCurrentDirectory() + @"\InfoUpdater.conf"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"\InfoUpdater.conf");
                }
                notify.Notify(1, "Удаление старого обновления завершено успешно");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool CheckedProcess()
        {
            try
            {
                notify.Notify(0, "Поиск процессов лаунчера");
                notify.SetMaximum(1);
                if (Process.GetProcessesByName("SZMK.Launcher").Length > 1)
                {
                    notify.Notify(1, "Найден дополнительный процесс лаунчера программы");
                    return true;
                }
                else
                {
                    notify.Notify(1, "Не найден дополнительный процесс лаунчера программы");
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool CheckedUpdate()
        {
            try
            {
                notify.SetMaximum(100);
                notify.Notify(0, "Попытка подключения к серверу обновления");
                if (CheckConnect())
                {
                    notify.Notify(20, "Подключение к серверу обновления успешно");
                    bool NeedUpdate = false;

                    TcpClient tcpClient = new TcpClient(Server, Convert.ToInt32(Port));

                    using (NetworkStream outputStream = tcpClient.GetStream())
                    {
                        using (BinaryWriter writer = new BinaryWriter(outputStream))
                        {
                            using (BinaryReader reader = new BinaryReader(outputStream))
                            {
                                notify.Notify(40, "Отправка параметров");
                                writer.Write(false);
                                writer.Write(false);

                                notify.Notify(60, "Отправка параметров");
                                writer.Write("SZMK.Launcher");

                                notify.Notify(80, "Отправка параметров");
                                writer.Write(Environment.MachineName);
                                writer.Write(Application.ProductVersion);

                                notify.Notify(100, "Получение необходимости обновления");
                                NeedUpdate = reader.ReadBoolean();
                            }
                        }
                    }

                    return NeedUpdate;
                }
                else
                {
                    MessageBox.Show("Не удается соединится с сервером обновления, обратитесь к администратору", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void Update()
        {
            try
            {
                notify.SetMaximum(1);

                notify.Notify(0, "Подготовка запуска обновления лаунчера");

                string PathUpdater = Directory.GetCurrentDirectory() + @"\Updater\SZMK.LauncherUpdater.exe";

                ProcessStartInfo procInfo = new ProcessStartInfo();

                procInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Updater";

                procInfo.FileName = PathUpdater;

                notify.Notify(1, "Запуск обновления");

                Process.Start(procInfo);

                Environment.Exit(0);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
