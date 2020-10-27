using System;

namespace SZMK.TeklaInteraction.Tekla2017.Common
{
    public interface IMessage
    {
        void Info(String Message);
        void Warning(String Message);
        void Error(String Message);
    }
}
