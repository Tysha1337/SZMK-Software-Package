namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    public interface ILogin
    {
        string LoginUser { get; set; }
        string PasswordUser { get; set; }

        bool GetParameters();
        bool SetParameters();
    }
}
