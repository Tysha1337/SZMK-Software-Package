using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Views.Autorization;

namespace SZMK.Desktop
{
    static class Program
    {
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
            Application.Run(new AVT_Autorization_F());
        }
    }
}
