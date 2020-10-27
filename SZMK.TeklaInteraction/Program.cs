using System;
using System.Threading;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Common;

namespace SZMK.TeklaInteraction
{
    static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ru-RU");
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            var controller = new ApplicationController(new LightInjectAdapder())
                        .RegisterView<Views.Interfaces.IMain, Views.Main>()
                        .RegisterService<Services.Interfaces.ISleep, Services.Sleep>()
                        .RegisterService<Shared.Services.Interfaces.IMailLogger, Shared.Services.MailLogger>()
                        .RegisterService<Shared.Services.Interfaces.ILogin, Shared.Services.Login>()
                        .RegisterService<Services.Interfaces.IChecked2017, Services.Checked2017>()
                        .RegisterService<Services.Interfaces.IChecked2018, Services.Checked2018>()
                        .RegisterService<Services.Interfaces.IChecked21_1, Services.Checked21_1>()
                        .RegisterView<Views.Interfaces.IChangePassword, Views.ChangePassword>()
                        .RegisterService<Services.Interfaces.IOperations, Services.Operations>()
                        .RegisterService<Shared.Services.Interfaces.IEncrypton, Shared.Services.Encryption>()
                        .RegisterService<Shared.Services.Interfaces.IHash, Shared.Services.Hash>()
                        .RegisterInstance(new ApplicationContext());

            controller.Run<Presenters.Main>();
        }
    }
}
