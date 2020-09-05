using System;

namespace SZMK.TeklaInteraction.Services.Interfaces
{
    interface IChecked21_1
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
