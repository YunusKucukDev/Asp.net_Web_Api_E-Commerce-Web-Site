using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Message.Dtos;
using Udemy.Message.Services;

namespace Udemy.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _service;

        public UserMessagesController(IUserMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var values = await _service.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("GetMesaageSendBox")]
        public async Task<IActionResult> GetMesaageSendBox(string id)
        {
            var values = await _service.GetSendBoxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMesaageInBox")]
        public async Task<IActionResult> GetMesaageInBox(string id)
        {
            var values = await _service.GetInboxMessageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
             await _service.CreateMessageAsync(createMessageDto);
            return Ok("mesaj başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
             await _service.DeleteMessageAsync(id);
            return Ok("mesaj başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _service.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj başarıyla güncellendi");
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var values = await _service.GetTotalMessageCount();
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCountByReceiverId")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _service.GetTotalMessageCountByReceiverId(id);
            return Ok(values);
        }

    }
}
