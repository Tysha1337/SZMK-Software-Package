using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Common;
using SZMK.TeklaInteraction.Services.Interfaces;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;
using SZMK.TeklaInteraction.Views;
using SZMK.TeklaInteraction.Views.Interfaces;

namespace SZMK.TeklaInteraction.Presenters
{
    class Main : BasePresener<IMain>
    {
        private readonly ISleep sleep;
        private readonly IMailLogger maillogger;
        private readonly ILogin login;
        private readonly IHash hash;
        private readonly IChecked2017 checked2017;
        private readonly IChecked2018 checked2018;
        private readonly IChecked21_1 checked21_1;
        private readonly IOperations operations;

        private readonly Logger logger;

        private readonly DataBase dataBase;
        private readonly Config config;

        const string pathRegistryKeyStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        const string applicationName = "Tekla_Interaction";

        public Main(IApplicationController controller, IMain view, ISleep sleep, IMailLogger maillogger, ILogin login, IHash hash, IChecked2017 checked2017, IChecked2018 checked2018, IChecked21_1 checked21_1, IOperations operations) : base(controller, view)
        {
            try
            {
                this.sleep = sleep;
                this.maillogger = maillogger;
                this.login = login;
                this.hash = hash;
                this.checked2017 = checked2017;
                this.checked2018 = checked2018;
                this.checked21_1 = checked21_1;
                this.operations = operations;

                logger = LogManager.GetCurrentClassLogger();
                dataBase = new DataBase();
                config = new Config();

                View.StartedProgram += () => StartedProgram();
                View.LoadSettings += () => LoadSettings();
                View.SaveSettings += () => SaveSettingsAsync();
                View.StoppedChecker += () => checked2018.Stopped();
                View.StoppedChecker += () => checked21_1.Stopped();
                View.StoppedChecker += () => checked2017.Stopped();
                checked2018.Load += (string message) => LoadOperation(message);
                checked21_1.Load += (string message) => LoadOperation(message);
                checked2017.Load += (string message) => LoadOperation(message);
                View.ResetAll += () => ResetAll();
                View.Reset21_1 += () => Reset21_1();
                View.Reset2018 += () => Reset2018();
                View.Reset2017 += () => Reset2017();

                logger.Info("Инициализация котроллера взаимодействия с Tekla успешна");
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
            }
        }

        #region RunningProgram
        private void StartedProgram()
        {
            try
            {
                sleep.Start();

                DeleteLogs();

                CheckedProcess();

                GetUsers();

                try
                {
                    if (Authorization(login.LoginUser, login.PasswordUser))
                    {
                        RestartChecked();
                    }
                }
                catch (Exception E)
                {
                    View.Error(E.Message + Environment.NewLine + "Ошибка авторизации пользователя введите данные заново и сохраните их");
                    View.OpenView();
                    View.FocusAuth();
                }

                logger.Info("Программа успешно запущена");
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
            }
        }
        public void CheckedProcess()
        {
            try
            {
                if (Process.GetProcessesByName("Tekla_Interaction").Length > 1)
                {
                    View.Error("Открыто более одной версии программы");
                    Environment.Exit(0);
                }
                logger.Info("Проверка количества процессов прошла успешно");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void GetUsers()
        {
            try
            {
                List<User> users = operations.GetUsers();
                logger.Info("Получение пользователей успешно");

                View.ShowUsers(users);
                logger.Info("Выгрузка пользователей успешна");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void DeleteLogs()
        {
            List<string> files = Directory.GetFiles(Application.StartupPath + @"/Logs").ToList();
            for (int i = 0; i < files.Count; i++)
            {
                DateTime create = Directory.GetCreationTime(files[i]);
                if (create < DateTime.Now.AddDays(-30))
                {
                    File.Delete(files[i]);
                }
            }
        }
        #endregion

        #region MainOperations
        private void LoadOperation(string Message)
        {
            logger.Info(Message);
            View.LoadOperation(Message);
        }
        private void RestartChecked()
        {
            checked2018.Stopped();
            checked2017.Stopped();
            checked21_1.Stopped();
            checked2018.Start();
            checked2017.Start();
            checked21_1.Start();
        }
        #endregion

        #region LoadSettings
        private void LoadSettings()
        {
            try
            {
                LoadMail();
                LoadConfig();
                LoadDataBase();
                LoadLogin();
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
            }
        }
        private void LoadMail()
        {
            View.Email = maillogger.Email;
            View.UserName = maillogger.Name;
            View.Login = maillogger.Login;
            View.Password = maillogger.Password;
            View.Host = maillogger.Host;
            View.Port = maillogger.Port;
            View.SSL = maillogger.SSL;
        }
        private void LoadDataBase()
        {
            View.NameDB = dataBase.Name;
            View.OwnerDB = dataBase.Owner;
            View.PortDB = dataBase.Port;
            View.IPDB = dataBase.IP;
            View.PasswordDB = dataBase.Password;
        }
        private void LoadConfig()
        {
            View.CheckedMarks = config.CheckMark;
        }
        private void LoadLogin()
        {
            View.LoginUser = login.LoginUser;
            View.PasswordUser = login.PasswordUser;
        }
        #endregion

        #region UserOperations
        public bool Authorization(string Login, string Pass)
        {
            try
            {
                logger.Info("Запущена авторизация пользователя");

                if (operations.Authrozation(Login, hash.GetSHA256(Pass)))
                {
                    User user = operations.GetUser(Login);

                    if (!user.UpdPassword)
                    {
                        ChangedPassword(user);

                        View.PasswordUser = "";

                        throw new Exception("После смены пароля необходимо заново ввести данные и сохранить их");
                    }
                    else
                    {
                        logger.Info("Авторизация прошла успешно");
                        return true;
                    }
                }
                else
                {
                    throw new Exception("Неправильный логин или пароль");
                }
            }
            catch (Exception Ex)
            {
                GetUsers();

                throw new Exception(Ex.Message, Ex);
            }

        }
        public void ChangedPassword(User user)
        {
            try
            {
                logger.Info("Запущено обновление пароля");

                Controller.Run<ChangePassword, User>(user);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region SavedSettings
        private async void SaveSettingsAsync()
        {
            Load Saving = new Load();
            Saving.Show();

            await Task.Run(() => SaveSetting());

            Saving.Close();
        }
        private void SaveSetting()
        {
            try
            {
                SaveConfig();
                SaveMail();
                SaveDataBase();
                SaveLogin();

                RestartChecked();
                View.Info("Настройки успешно сохранены");
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
            }
        }
        private void SaveMail()
        {
            maillogger.Email = View.Email;
            maillogger.Name = View.UserName;
            maillogger.Login = View.Login;
            maillogger.Password = View.Password;
            maillogger.Host = View.Host;
            maillogger.Port = View.Port;
            maillogger.SSL = View.SSL;

            if (!maillogger.SetParametersConnect())
            {
                maillogger.GetParametersConnect();
                throw new Exception("Ошибка параметров отправки логов");
            }
        }
        private void SaveDataBase()
        {
            dataBase.Name = View.NameDB;
            dataBase.Owner = View.OwnerDB;
            dataBase.Port = View.PortDB;
            dataBase.IP = View.IPDB;
            dataBase.Password = View.PasswordDB;

            if (!dataBase.SetParametersConnect())
            {
                dataBase.GetParametersConnect();
                throw new Exception("Ошибка параметров базы данных");
            }
        }
        private void SaveConfig()
        {
            config.CheckMark = View.CheckedMarks;
            if (!config.SetParametersConnect())
            {
                config.GetParametersConnect();
                throw new Exception("Ошибка параметров конфигурации");
            }
        }
        private void SaveLogin()
        {
            if (Authorization(View.LoginUser, View.PasswordUser))
            {
                login.LoginUser = View.LoginUser;
                login.PasswordUser = View.PasswordUser;
                if (!login.SetParameters())
                {
                    throw new Exception("Ошибка параметров сохранения пользователя");
                }
            }
        }
        #endregion

        #region Reset
        public void ResetAll()
        {
            checked21_1.Reset();
            checked2018.Reset();
            checked2017.Reset();
        }
        public void Reset21_1()
        {
            checked21_1.Reset();
        }
        public void Reset2018()
        {
            checked2018.Reset();
        }
        public void Reset2017()
        {
            checked2017.Reset();
        }
        #endregion
    }
}
