using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Comment.Contex;
using Udemy.Comment.Entities;

namespace Udemy.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContex _contex;

        public CommentsController(CommentContex contex)
        {
            _contex = contex;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _contex.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _contex.UserComments.Find(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _contex.UserComments.Add(userComment);
            _contex.SaveChanges();
            return Ok("işlem baaşrıyla gerçekleşti");

        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _contex.UserComments.Update(userComment);
            _contex.SaveChanges();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _contex.UserComments.Find(id);
            _contex.UserComments.Remove(values);
            _contex.SaveChanges();
            return Ok("işlem başarıyla gerçekleşti");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _contex.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }
    }
}
