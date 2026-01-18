namespace Udemy.WebUI.Services.StatisticServices.CommentStatisticService
{
    public interface ICommentStatisticService
    {
        Task<int> TotalCommentCount();
        Task<int> ActiveCommentCount();
        Task<int> PasiveCommentCount();
     }
}
