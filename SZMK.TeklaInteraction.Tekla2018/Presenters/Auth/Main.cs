using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;
using SZMK.TeklaInteraction.Tekla2018.Common;
using SZMK.TeklaInteraction.Tekla2018.Services.Auth.Interfaces;
using SZMK.TeklaInteraction.Tekla2018.Views.Auth.Interfaces;

namespace SZMK.TeklaInteraction.Tekla2018.Presenters.Auth
{
    class Main : BasePresener<IMain>
    {
        private readonly IMailLogger maillogger;
        private readonly Services.Server.Interfaces.IServer server;
        private readonly IOperations operations;
        private readonly IHash hash;
        private readonly ILogin login;

        private readonly Logger logger;

        public Main(IApplicationController controller, IMain view, IOperations operations, IMailLogger maillogger, ILogin login, Services.Server.Interfaces.IServer server, IHash hash) : base(controller, view)
        {
            try
            {
                this.operations = operations;
                this.maillogger = maillogger;
                this.login = login;
                this.server = server;
                this.hash = hash;

                logger = LogManager.GetCurrentClassLogger();

                view.StartedProgram += () => StartedProgram();

                logger.Info("Инициализация контроллера авторизации выполнена успешно");
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
                View.Close();
            }
        }
        public void StartedProgram()
        {
            try
            {
                DeleteLogs();

                Authorization(login.LoginUser, login.PasswordUser);

                logger.Info("Программа успешно запущена");
            }
            catch (Exception Ex)
            {
                maillogger.AsyncSendingLog(Ex.ToString());
                View.Error(Ex.Message);
                View.Close();
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
        public void Authorization(string Login, string Pass)
        {
            try
            {
                logger.Info("Запущена авторизация пользоавтеля");

                if (operations.Authrozation(Login, hash.GetSHA256(Pass)))
                {
                    User user = operations.GetUser(Login);

                    if (!user.UpdPassword)
                    {
                        throw new Exception("Необходимо обновить пароль в основной программе");
                    }
                    else
                    {
                        logger.Info("Авторизация успешно пройдена");

                        RunningServer(user);
                    }
                }
                else
                {
                    throw new Exception("Неправильный логин или пароль");
                }
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }

        }
        public void RunningServer(User user)
        {
            try
            {
                server.StartServer(user);
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }

        }
    }
}
