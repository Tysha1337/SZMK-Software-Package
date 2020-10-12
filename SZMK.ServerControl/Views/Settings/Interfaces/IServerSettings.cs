using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.ServerControl.Common;

namespace SZMK.ServerControl.Views.Settings.Interfaces
{
    public interface IServerSettings : IView
    {
        event Action LoadSettings;

        string IP { get; set; }
        int Port { get; set; }
    }
}
