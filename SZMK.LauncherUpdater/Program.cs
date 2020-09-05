
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SZMK.LauncherUpdater.Models;

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

                if (GetParametersConnect() && CheckedProcess() && CheckConnect())
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
                if (File.Exists(Directory.GetCurrentDirectory() + @"\InfoLauncher.conf"))
                {
                    File.Delete(Directory.GetCurrentDirectory() + @"\InfoLauncher.conf");
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
                    using (BinaryWriter writer = new BinaryWriter(Stream, Encoding.UTF8))
                    {
                        using (BinaryReader reader = new BinaryReader(Stream, Encoding.UTF8))
                        {
                            Info("Отправка необходимых флагов и наименования приложения");

                            writer.Write(false);
                            writer.Write(true);

                            writer.Write("SZMK.Launcher");
                            writer.Write(Environment.MachineName);

                            writer.Write(GetVersion());

                            Info("Получение файла информации обновления");

                            using (FileStream fileStream = File.Open(Directory.GetCurrentDirectory() + @"\InfoLauncher.conf", FileMode.Create))
                            {
                                long lenght = reader.ReadInt64();

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
                            Info("Получение файла информации обновления успешно");

                            writer.Write(true);

                            Info("Чтение количества файлов");

                            int CountFiles = reader.ReadInt32();

                            writer.Write(true);

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
                                writer.Write(i);
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
                XDocument info = XDocument.Load(Directory.GetCurrentDirectory() + @"\InfoLauncher.conf");

                List<FileAndMove> files = new List<FileAndMove>();

                foreach (var file in info.Element("Program").Elements("File"))
                {
                    files.Add(new FileAndMove { FileName = file.Element("FileName").Value, Move = file.Element("Move").Value });
                }

                foreach (var file in files.FindAll(p => p.Move.Contains("Remove")))
                {
                    File.Delete($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}");
                    if (Directory.GetDirectories(Path.GetDirectoryName($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}")).Count() == 0 && Directory.GetFiles(Path.GetDirectoryName($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}")).Length == 0)
                    {
                        Directory.Delete(Path.GetDirectoryName($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}"));
                    }
                }

                foreach (var file in files.FindAll(p => !p.Move.Contains("Remove")))
                {
                    if (!Directory.Exists(Path.GetDirectoryName($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}")))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}"));
                    }

                    File.Copy(Directory.GetCurrentDirectory() + @"\Temp\" + file.FileName, $@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\{file.FileName}", true);
                }
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
        private static string GetVersion()
        {
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo($@"{Path.GetDirectoryName(Directory.GetCurrentDirectory())}\SZMK.Launcher.exe");
            return myFileVersionInfo.FileVersion;
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
