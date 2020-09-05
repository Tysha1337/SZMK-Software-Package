using System;

namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    public interface IEncrypton
    {
        String EncryptRSA(String InputPassword);
        String DecryptRSA(String OutputPassword);
    }
}
