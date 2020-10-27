using System;
using SZMK.TeklaInteraction.Tekla2017.Common;

namespace SZMK.TeklaInteraction.Tekla2017.Views.Auth.Interfaces
{
    interface IMain : IView, IMessage
    {
        void Hide();

        event Action StartedProgram;
    }
}
