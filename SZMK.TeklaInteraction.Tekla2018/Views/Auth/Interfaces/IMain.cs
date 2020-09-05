using System;
using SZMK.TeklaInteraction.Tekla2018.Common;

namespace SZMK.TeklaInteraction.Tekla2018.Views.Auth.Interfaces
{
    interface IMain : IView
    {
        void Hide();

        event Action StartedProgram;
    }
}
