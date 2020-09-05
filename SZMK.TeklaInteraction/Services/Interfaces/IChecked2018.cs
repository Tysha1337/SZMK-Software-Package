using System;

namespace SZMK.TeklaInteraction.Services.Interfaces
{
    interface IChecked2018
    {
        event Action<string> Load;
        void Start();

        void CheckedAsync();
        void Checked();

        void Reset();

        void Stopped();

        void Error(string Message);
    }
}
