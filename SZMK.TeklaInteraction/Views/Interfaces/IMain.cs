using System;
using System.Collections.Generic;
using SZMK.TeklaInteraction.Common;
using SZMK.TeklaInteraction.Shared.Models;

namespace SZMK.TeklaInteraction.Views.Interfaces
{
    interface IMain : IView
    {
        event Action StartedProgram;
        event Action LoadSettings;
        event Action SaveSettings;
        event Action StoppedChecker;
        event Action ResetAll;
        event Action Reset21_1;
        event Action Reset2018;
        event Action Reset2017;

        string Email { get; set; }
        string UserName { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        bool SSL { get; set; }

        string NameDB { get; set; }
        string OwnerDB { get; set; }
        string PortDB { get; set; }
        string IPDB { get; set; }
        string PasswordDB { get; set; }

        bool CheckedMarks { get; set; }

        string LoginUser { get; set; }
        string PasswordUser { get; set; }

        void LoadOperation(string Message);
        void ClearPassword();
        void ShowUsers(List<User> users);
        void FocusAuth();
        void OpenView();
    }
}
