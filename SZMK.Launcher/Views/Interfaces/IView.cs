using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Launcher.Views.Interfaces
{
    interface IView
    {
        void Info(String Message);
        void Warning(String Message);
        void Error(String Message);
    }
}
