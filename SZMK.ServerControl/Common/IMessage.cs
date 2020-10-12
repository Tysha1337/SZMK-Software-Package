using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.ServerControl.Common
{
    public interface IMessage
    {
        void Info(String Message);
        void Warning(String Message);
        void Error(String Message);
    }
}
