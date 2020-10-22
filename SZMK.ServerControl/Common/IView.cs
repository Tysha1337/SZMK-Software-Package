using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.ServerControl.Common
{
    public interface IView
    {
        void Show();

        DialogResult ShowDialog();

        void Close();
    }
}
