using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.BotLogger.Views.Interfaces
{
    interface IBaseView
    {
        void Info(string Message);
        void Warn(string Message);
        void Error(string Message);
    }
}
