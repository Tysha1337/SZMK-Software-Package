using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Launcher.Services.Launcher;
using SZMK.Launcher.Services.Product;
using SZMK.Launcher.Services.Updater;
using SZMK.Launcher.Views.Interfaces;

namespace SZMK.Launcher.Views
{
    public partial class Main : Form, IView
    {
        private readonly Logger logger;

        delegate void NotifyCallback(int value, string message);

        private OperationsUpdater OperationsUpdater;
        private OperationsLauncher OperationsLauncher;
        private OperationsProduct OperationsProduct;

        public Main()
        {
            try
            {
                InitializeComponent();
                logger = LogManager.GetCurrentClassLogger();
                logger.Info("Инициализация успешно пройдена");
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
                logger.Error(Ex.ToString());
                Environment.Exit(0);
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                StartAsync();
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
                logger.Error(Ex.ToString());
                Environment.Exit(0);
            }
        }
        private async void StartAsync()
        {
            try
            {
                Notify(0, "Запуск лаунчера");
                await Task.Run(() => Start());
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
                logger.Error(Ex.ToString());
                Environment.Exit(0);
            }
        }
        private void Start()
        {
            try
            {
                CheckUpdater();
                CheckLauncher();
                CheckProduct();

                StartApp();
                Application.Exit();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckUpdater()
        {
            try
            {
                OperationsUpdater = new OperationsUpdater(this);

                Notify(0, "Начало проверки обновления основного приложения");

                if (OperationsUpdater.CheckedUpdate())
                {
                    while (!OperationsUpdater.CheckedProcess())
                    {
                        if (MessageBox.Show("Для обновления необходимо закрыть остальные копии SZMK.LauncherUpdater, нажмите \"Повторить\" для повторной проверки или \"Отмена\" для выхода из обновления", "Внимание", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            logger.Info("Пользователь отменил обновление лаунчера");
                            Environment.Exit(0);
                        }
                    }

                    OperationsUpdater.Update();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckLauncher()
        {
            try
            {
                OperationsLauncher = new OperationsLauncher(this);

                OperationsLauncher.DeleteLogAndTemp();

                Notify(0, "Начало проверки обновления лаунчера");

                if (OperationsLauncher.CheckedUpdate())
                {
                    while (OperationsLauncher.CheckedProcess())
                    {
                        if (MessageBox.Show("Для обновления необходимо закрыть остальные копии лаунчера программы, нажмите \"Повторить\" для повторной проверки или \"Отмена\" для выхода из обновления", "Внимание", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            logger.Info("Пользователь отменил обновление лаунчера");
                            Environment.Exit(0);
                        }
                    }

                    OperationsLauncher.Update();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckProduct()
        {
            try
            {
                OperationsProduct = new OperationsProduct(this);

                Notify(0, "Начало проверки обновления основного приложения");

                if (OperationsProduct.CheckedUpdate())
                {
                    while (!OperationsProduct.CheckedProcess())
                    {
                        if (MessageBox.Show("Для обновления необходимо закрыть остальные копии основной программы, нажмите \"Повторить\" для повторной проверки или \"Отмена\" для выхода из обновления", "Внимание", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            logger.Info("Пользователь отменил обновление лаунчера");
                            Environment.Exit(0);
                        }
                    }

                    OperationsProduct.Update();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void StartApp()
        {
            try
            {
                SetMaximum(1);

                Notify(0, "Запуск основного приложения");

                OperationsProduct.Start();

                Notify(1, "Запуск выполнен успешно, закрытие лаунчера");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void Notify(int percent, string Message)
        {
            if (Operations_PB.InvokeRequired)
            {
                NotifyCallback d = new NotifyCallback(Notify);
                this.Invoke(d, new object[] { percent, Message });
            }
            else
            {
                logger.Info(Message);
                Operations_PB.Value = percent;
                Operations_L.Text = Message;
            }
        }
        public void SetMaximum(int Max)
        {
            Operations_PB.Invoke((MethodInvoker)delegate ()
            {
                Operations_PB.Maximum = Max;
            });
        }
        public void Error(string Message)
        {
            logger.Error(Message);
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Warning(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
