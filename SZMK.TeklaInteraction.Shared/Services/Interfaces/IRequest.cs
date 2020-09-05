using System.Collections.Generic;
using SZMK.TeklaInteraction.Shared.Models;

namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    public interface IRequest
    {
        List<User> GetAllUsers();
    }
}
