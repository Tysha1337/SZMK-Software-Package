using System;
using SZMK.TeklaInteraction.Tekla21_1.Common;

namespace SZMK.TeklaInteraction.Tekla21_1.Views.Auth.Interfaces
{
    interface IMain : IView
    {
        void Hide();

        event Action StartedProgram;
    }
}
