using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Services.Interfaces;
using SZMK.TeklaInteraction.Shared.Services;

namespace SZMK.TeklaInteraction.Services
{
    class Checked2017 : IChecked2017
    {
        private readonly Logger logger;
        private readonly MailLogger maillogger;

        public Checked2017()
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
                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count();
                id = 0;
                if (count != 0)
                {
                    id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).First().Id;
                    Reset();
                }
                while (flag)
                {
                    if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count() != count)
                    {
                        if (count == 0)
                        {
                            Load?.Invoke("Основная копия Tekla 2017 открыта");
                            Reset();
                            Thread.Sleep(5000);
                        }
                        else if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count() > 0)
                        {
                            if (Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).First().Id != id)
                            {
                                Reset();
                                Thread.Sleep(5000);
                            }
                            else
                            {
                                if (count > Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count())
                                {
                                    Load?.Invoke("Одна из копий Tekla 2017 закрыта");
                                }
                                else
                                {
                                    Load?.Invoke("Tekla 2017 запущена повторно");
                                }
                                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count();
                                id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).First().Id;
                            }
                        }
                        else
                        {
                            Load?.Invoke("Все копии Tekla 2017 закрыты");
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
                for (int i = 0; i < Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla2017").Length; i++)
                {
                    Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla2017")[i].Kill();
                }

                count = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).Count();

                if (count > 0)
                {
                    id = Process.GetProcessesByName("TeklaStructures").Where(p => p.MainModule.FileName.IndexOf("2017") != -1).First().Id;

                }
                else
                {
                    id = 0;
                }

                System.Diagnostics.ProcessStartInfo infoStartProcess = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = Application.StartupPath + @"\Tekla2017\SZMK.TeklaInteraction.Tekla2017.exe",
                    WindowStyle = ProcessWindowStyle.Normal
                };
                System.Diagnostics.Process.Start(infoStartProcess);
                Load?.Invoke("Выполенен перезапуск взаимодействия с Tekla 2017");
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
                Load?.Invoke("Слушание процессов Tekla 2017 начато");

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

                for (int i = 0; i < Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla2017").Length; i++)
                {
                    Process.GetProcessesByName("SZMK.TeklaInteraction.Tekla2017")[i].Kill();
                }
                Load?.Invoke("Успешная остановка слушания процессов Tekla 2017");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
