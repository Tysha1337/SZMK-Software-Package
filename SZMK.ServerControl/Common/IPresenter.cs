using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.ServerControl.Common
{
    public interface IPresenter
    {
        void Run();
        DialogResult RunDialog();
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument);
        DialogResult RunDialog(TArg argument);
    }
}
