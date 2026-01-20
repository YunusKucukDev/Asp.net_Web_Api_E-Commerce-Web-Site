namespace Udemy.SignarRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByRecceiverId(string id);
        
    }
}
