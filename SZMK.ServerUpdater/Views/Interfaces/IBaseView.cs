using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.ServerUpdater.Views.Interfaces
{
    interface IBaseView
    {
        void Info(string Message);
        void Warn(string Message);
        void Error(Exception Ex);
    }
}
