using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Comment.Contex;
using Udemy.Comment.Entities;

namespace Udemy.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContex _context;

        public CommentsController(CommentContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _context.UserComments.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(UserComment userComment)
        {
            await _context.UserComments.AddAsync(userComment);
            await _context.SaveChangesAsync();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            await _context.SaveChangesAsync();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var value = await _context.UserComments.FindAsync(id);
            if (value == null)
                return NotFound();

            _context.UserComments.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public async Task<IActionResult> CommentListByProductId(string id)
        {
            var values = await _context.UserComments
                                       .Where(x => x.ProductId == id)
                                       .ToListAsync();
            return Ok(values);
        }

        [HttpGet("ActiveCommentCount")]
        public async Task<IActionResult> ActiveCommentCount()
        {
            var value = await _context.UserComments.CountAsync(x => x.Status == true);
            return Ok(value);
        }

        [HttpGet("PasiveCommentCount")]
        public async Task<IActionResult> PasiveCommentCount()
        {
            var value = await _context.UserComments.CountAsync(x => x.Status == false);
            return Ok(value);
        }

        [HttpGet("TotalCommentCount")]
        public async Task<IActionResult> TotalCommentCount()
        {
            var value = await _context.UserComments.CountAsync();
            return Ok(value);
        }
    }
}
