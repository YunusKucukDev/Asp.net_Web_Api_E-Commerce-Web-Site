using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Comment.Contex;

namespace Udemy.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentstatisticsController : ControllerBase
    {

        private readonly CommentContex _contex;

        public CommentstatisticsController(CommentContex contex)
        {
            _contex = contex;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            var values = _contex.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
