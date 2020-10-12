using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SZMK.ServerControl.Common;
using SZMK.ServerControl.Views.Settings.Interfaces;

namespace SZMK.ServerControl.Presenters.Settings
{
    class ServerSettingPresenter : BasePresener<IServerSettings>
    {
        public ServerSettingPresenter(IApplicationController controller, IServerSettings view) : base(controller, view)
        {
            try
            {
                View.LoadSettings += () => LoadSettings();
            }
            catch
            {

            }
        }

        private void LoadSettings()
        {
            View.IP = Dns.GetHostByName(Dns.GetHostName()).AddressList.First().ToString();
            View.Port = 25565;
        }
    }
}
