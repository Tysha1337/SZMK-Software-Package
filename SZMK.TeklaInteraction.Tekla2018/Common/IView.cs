using System;

namespace SZMK.TeklaInteraction.Tekla2018.Common
{
    public interface IView
    {
        void Show();
        void Close();

        void Info(String Message);
        void Warning(String Message);
        void Error(String Message);
    }
}
