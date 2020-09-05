using System;
using SZMK.TeklaInteraction.Common;

namespace SZMK.TeklaInteraction.Views.Interfaces
{
    interface IChangePassword : IView
    {
        event Action UpdatePassword;
        string OldPassword { get; }
        string NewPassword { get; }
        string ComparePassword { get; }
    }
}
