using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Views.Shared.Interfaces
{
    public interface INotifyProcess
    {
        void Notify(int percent, string Message);
        void SetMaximum(int Max);
        void CloseAsync();
    }
}
