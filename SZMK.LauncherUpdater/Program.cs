using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.LauncherUpdater
{
    class Program : BaseProgram
    {
        private static Logger logger;

        static void Main(string[] args)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                Info("Проверка подключения к серверу обновления и выполняемых процессов");

                if (CheckedProcess() && CheckConnect())
                {
                    Info("Проверка процессов прошла успешно");
                    Info("Подключение к серверу обновления успешно");

                    Info("Начато удаление старых лог файлов");
                    DeleteLogs();
                    Info("Удаление старых лог файлов успешно");
                    Info("Начато удаление старого обновления");
                    DeleteTemp();
                    Info("Удаление старого обновление успешно");

                    DownloadFiles();
                    RemoveAndCopeFiles();

                    Info("Обновление прошло успешно");

                    Info("Открытие лаунчера");

                    OpenLauncher();

                    Info("Закрытие приложения");

                    Environment.Exit(0);
                }
                else
                {
                    throw new Exception("Ошибка подключения к серверу обновления");
                }

            }
            catch (Exception Ex)
            {
                Error(Ex);
                Console.ReadKey();
            }
        }
        private static bool CheckedProcess()
        {
            try
            {
                if (Process.GetProcessesByName("SZMK.Launcher").Length != 0)
                {
                    throw new Exception("Необходимо закрыть все копии SZMK.Launcher перед обновлением ПО");
                }
                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void DeleteLogs()
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Logs"))
                {
                    List<string> files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Logs").ToList();
                    for (int i = 0; i < files.Count; i++)
                    {
                        DateTime create = Directory.GetCreationTime(files[i]);
                        if (create < DateTime.Now.AddDays(-30))
                        {
                            File.Delete(files[i]);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void DeleteTemp()
        {
            try
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + @"\Temp"))
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + @"\Temp", true);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void DownloadFiles()
        {
            try
            {
                Info("Начало скачивания файлов обновления");

                TcpClient tcpClient = new TcpClient(Server, Convert.ToInt32(Port));

                using (NetworkStream Stream = tcpClient.GetStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(Stream))
                    {
                        using (BinaryReader reader = new BinaryReader(Stream))
                        {
                            Info("Отправка необходимых флагов и наименования приложения");

                            writer.Write(false);
                            writer.Write(true);
                            writer.Write("Launcher");

                            Info("Чтение количества файлов");

                            int CountFiles = reader.ReadInt32();

                            for (int i = 0; i < CountFiles; i++)
                            {
                                string PathFile = reader.ReadString();

                                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Temp\" + Path.GetDirectoryName(PathFile));

                                long lenght = reader.ReadInt64();

                                using (FileStream fileStream = File.Open(Directory.GetCurrentDirectory() + @"\Temp\" + PathFile, FileMode.Create))
                                {
                                    long totalBytes = 0;
                                    int readBytes = 0;
                                    byte[] buffer = new byte[8192];

                                    do
                                    {
                                        readBytes = Stream.Read(buffer, 0, buffer.Length);
                                        fileStream.Write(buffer, 0, readBytes);
                                        totalBytes += readBytes;
                                    } while (tcpClient.Connected && totalBytes < lenght);
                                }
                                Info($"Скачивание файлов {i} из {CountFiles}");
                            }
                        }
                    }
                }
                Info("Скачивание успешно завершено");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void RemoveAndCopeFiles()
        {
            try
            {
                Info("Удаление старых файлов начато");
                foreach (var file in Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).FullName))
                {
                    File.Delete(file);
                }
                Info("Удаление старых файлов завершено");
                Info("Удаление старых папок начато");
                foreach (var directory in Directory.GetDirectories(Directory.GetParent(Directory.GetCurrentDirectory()).FullName))
                {
                    string check = Path.GetFileName(directory);
                    if (check != "Product" && check != "Updater")
                    {
                        Directory.Delete(directory, true);
                    }
                }
                Info("Удаление старых папок завершено");
                Info("Копирование новых файлов и папок начато");
                Directory.Move(Directory.GetCurrentDirectory() + @"\Temp", Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
                Info("Копирование новых файлов и папок завершено");

                //foreach(var file in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Temp"))
                //{
                //    File.Copy(file, Directory.GetParent(Directory.GetCurrentDirectory()).FullName+@"\"+Path.GetFileName(file));
                //}

                //foreach(var directory in Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\Temp"))
                //{
                //    Directory.Move(directory,);
                //}
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void OpenLauncher()
        {
            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();

                procInfo.FileName = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\SZMK.Launcher.exe";

                procInfo.WorkingDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

                Process.Start(procInfo);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private static void Info(string message)
        {
            logger.Info(message);
            Console.WriteLine(message);
        }
        private static void Error(Exception Ex)
        {
            logger.Error(Ex.ToString());
            Console.WriteLine(Ex.Message);
        }
    }
}
