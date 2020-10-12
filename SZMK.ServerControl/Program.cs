using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.ServerControl.Common;

namespace SZMK.ServerControl
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
            var controller = new ApplicationController(new LightInjectAdapter())
                        .RegisterView<Views.Main.Interface.IMain, Views.Main.Main>()
                        .RegisterView<Views.Settings.Interfaces.IServerSettings,Views.Settings.ServerSettings>()
                        .RegisterInstance(new ApplicationContext());

            controller.Run<Presenters.Main.MainPresenter>();
        }
    }
}
