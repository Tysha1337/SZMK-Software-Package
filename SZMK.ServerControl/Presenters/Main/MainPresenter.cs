using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.ServerControl.Common;
using SZMK.ServerControl.Presenters.Settings;
using SZMK.ServerControl.Views.Main.Interface;
using SZMK.ServerControl.Views.Settings;

namespace SZMK.ServerControl.Presenters.Main
{
    class MainPresenter : BasePresener<IMain>
    {
        public MainPresenter(IApplicationController controller, IMain view) : base(controller, view)
        {
            try
            {
                View.SettingsServer += () => SettingsServer();
            }
            catch
            {

            }
        }

        private void SettingsServer()
        {
            if (Controller.RunDialog<ServerSettingPresenter>()==System.Windows.Forms.DialogResult.OK)
            {
                throw new Exception();
            }
        }
    }
}
