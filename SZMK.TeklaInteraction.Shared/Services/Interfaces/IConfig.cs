namespace SZMK.TeklaInteraction.Shared.Services.Interfaces
{
    interface IConfig
    {
        bool SetParametersConnect();
        bool GetParametersConnect();

        bool CheckMark { get; set; }
    }
}
