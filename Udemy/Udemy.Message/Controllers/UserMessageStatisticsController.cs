using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Message.Services;

namespace Udemy.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService userMessageService;

        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            this.userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int messageCount = await userMessageService.GetTotalMessageCount();
            return Ok(messageCount);
        }
    }
}
