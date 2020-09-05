using System.Collections.Generic;
using SZMK.TeklaInteraction.Shared.Models;

namespace SZMK.TeklaInteraction.Services.Interfaces
{
    interface IOperations
    {
        List<User> GetUsers();
        User GetUser(string Login);
        bool Authrozation(string Login, string Password);
        bool UpdatePassword(User user, string NewPassword);
    }
}
