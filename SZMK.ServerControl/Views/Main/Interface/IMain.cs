using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.ServerControl.Common;

namespace SZMK.ServerControl.Views.Main.Interface
{
    public interface IMain : IView, IMessage
    {
        event Action SettingsServer;
    }
}
