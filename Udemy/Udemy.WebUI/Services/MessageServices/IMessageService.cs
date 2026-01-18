using Udemy.DtoLayer.MessagesDtos;

namespace Udemy.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendBoxDto>> GetSendBoxMessageAsync(string id);
        
    }
}
