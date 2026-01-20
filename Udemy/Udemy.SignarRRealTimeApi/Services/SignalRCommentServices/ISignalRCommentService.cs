namespace Udemy.SignarRRealTimeApi.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
