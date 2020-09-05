using System.Threading.Tasks;

namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    public interface IMailLogger
    {

        bool CheckConnect();
        Task AsyncSendingLog(string Message);
        void SendErrorLog(string Message);
        bool SetParametersConnect();
        bool GetParametersConnect();

        string Email { get; set; }
        string Name { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        bool SSL { get; set; }
    }
}
