using NLog;
using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services;
using SZMK.TeklaInteraction.Tekla2017.Services.Server.Interfaces;
using SZMK.TeklaInteraction.Tekla2017.Views.Shared;

namespace SZMK.TeklaInteraction.Tekla2017.Services.Server
{
    class Server : IServer
    {
        private readonly Logger logger;
        private readonly MailLogger maillogger;

        public Server()
        {
            logger = LogManager.GetCurrentClassLogger();
            maillogger = new MailLogger();
        }

        public void StartServer(User user)
        {
            try
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    var server = new NamedPipeServerStream("Tekla2017");
                    StreamReader reader = new StreamReader(server);
                    while (true)
                    {
                        server.WaitForConnection();

                        logger.Info("Клиент подключился");

                        Loading Load = new Loading();
                        Load.Show();

                        Tekla tekla = new Tekla(Load);
                        if (tekla.CheckConnect())
                        {
                            logger.Info("Модель подключена");

                            tekla.GetData(user);
                        }
                        else
                        {
                            logger.Info("Модель не подключена");

                            MessageBox.Show("Ошибка подключения модели", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        server.Disconnect();
                    }
                });
            }
            catch (Exception E)
            {
                maillogger.SendErrorLog(E.ToString());
                logger.Error(E.ToString());
                StartServer(user);
            }
        }
    }
}
