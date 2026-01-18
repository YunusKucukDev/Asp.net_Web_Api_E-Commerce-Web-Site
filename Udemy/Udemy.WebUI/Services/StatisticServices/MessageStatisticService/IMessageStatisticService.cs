namespace Udemy.WebUI.Services.StatisticServices.MessageStatisticService
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
    }
}
