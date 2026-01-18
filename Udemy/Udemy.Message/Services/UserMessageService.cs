using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Message.DAL.Contex;
using Udemy.Message.DAL.Entities;
using Udemy.Message.Dtos;

namespace Udemy.Message.Services
{
    

    public class UserMessageService : IUserMessageService
    {

        private readonly MessageContex _contex;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContex contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createMessageDto);
            await _contex.UserMessages.AddAsync(value);
            _contex.SaveChanges();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _contex.UserMessages.FindAsync(id);
            _contex.UserMessages.Remove(values);
            _contex.SaveChanges();
        } 

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _contex.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _contex.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }

        public async Task<List<ResultInboxDto>> GetInboxMessageAsync(string id)
        {
            var values = await _contex.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxDto>>(values);
        }

        public async Task<List<ResultSendBoxDto>> GetSendBoxMessageAsync(string id)
        {
            var values = await _contex.UserMessages.Where(x => x.SendedId == id).ToListAsync();
            return _mapper.Map<List<ResultSendBoxDto>>(values);
        }

        public async Task<int> GetTotalMessageCount()
        {
            var values = await _contex.UserMessages.CountAsync();
            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var entity = _mapper.Map<UserMessage>(updateMessageDto);
            _contex.UserMessages.Update(entity);
            await _contex.SaveChangesAsync();
        }
    }
}
