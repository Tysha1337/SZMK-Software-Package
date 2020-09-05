using System;

namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    public interface IHash
    {
        string GetSHA256(String Password);
    }
}
