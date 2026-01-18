using Udemy.Message.Dtos;

namespace Udemy.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendBoxDto>> GetSendBoxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task DeleteMessageAsync(int id);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();
    }
}
