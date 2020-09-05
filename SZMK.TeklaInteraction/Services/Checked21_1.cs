using NLog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Services.Interfaces;
using SZMK.TeklaInteraction.Shared.Services;

namespace SZMK.TeklaInteraction.Services
{
    class Checked21_1 : IChecked21_1
    {
        private readonly Logger logger;
        private readonly MailLogger maillogger;

        public Checked21_1()
        {
            logger = LogManager.GetCurrentClassLogger();
            maillogger = new MailLogger();
        }

        private int countExeption = 0;
        private int count = 0;
        private int id = 0;

        private bool flag;

        public event Action<string> Load;

        public void Checked()
        {
            try
            {
                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count();
                id = 0;
                if (count != 0)
                {
                    id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).First().Id;
                    Reset();
                }
                while (flag)
                {
                    if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count() != count)
                    {
                        if (count == 0)
                        {
                            Load?.Invoke("Основная копия Tekla 21.1 открыта");
                            Reset();
                            Thread.Sleep(5000);
                        }
                        else if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count() > 0)
                        {
                            if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).First().Id != id)
                            {
                                Reset();
                                Thread.Sleep(5000);
                            }
                            else
                            {
                                if (count > Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count())
                                {
                                    Load?.Invoke("Одна из копий Tekla 21.1 закрыта");
                                }
                                else
                                {
                                    Load?.Invoke("Tekla 21.1 запущена повторно");
                                }
                                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count();
                                id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).First().Id;
                            }
                        }
                        else
                        {
                            Load?.Invoke("Все копии Tekla 21.1 закрыты");
                            Reset();
                            count = 0;
                        }
                    }
                    Thread.Sleep(2500);
                    countExeption = 0;
                }
            }
            catch (Exception e)
            {
                if (countExeption < 5)
                {
                    Thread.Sleep(2000);
                    CheckedAsync();
                }
                else
                {
                    Error(e.ToString());
                }
                countExeption++;
            }
        }

        public async void CheckedAsync()
        {
            await Task.Run(() => Checked());
        }

        public void Error(string Message)
        {
            logger.Error(Message);
            maillogger.AsyncSendingLog(Message);
        }

        public void Reset()
        {
            try
            {
                for (int i = 0; i < Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla21_1").Length; i++)
                {
                    Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla21_1")[i].Kill();
                }

                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).Count();

                if (count > 0)
                {
                    id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("21.1") != -1).First().Id;
                }
                else
                {
                    id = 0;
                }

                System.Diagnostics.ProcessStartInfo infoStartProcess = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = Application.StartupPath + @"\Tekla21_1\SZMK.TeklaInteraction.Tekla21_1.exe",
                    WindowStyle = ProcessWindowStyle.Normal
                };
                System.Diagnostics.Process.Start(infoStartProcess);
                Load?.Invoke("Выполенен перезапуск взаимодействия с Tekla 21.1");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void Start()
        {
            try
            {
                flag = true;
                CheckedAsync();
                Load?.Invoke("Слушание процессов Tekla 21.1 начато");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void Stopped()
        {
            try
            {
                flag = false;

                for (int i = 0; i < Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla21_1").Length; i++)
                {
                    Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla21_1")[i].Kill();
                }
                Load?.Invoke("Успешная остановка слушания процессов Tekla 21.1");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
