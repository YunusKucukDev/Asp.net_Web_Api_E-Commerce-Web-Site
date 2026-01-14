using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CommnetDtos;
using Udemy.WebUI.Services.CommentServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
       private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Yorum işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum listesi";

            var values = await _commentService.GetAllCommentAsync();

            return View(values);
        }


        

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {

            ViewBag.v0 = "Yorum işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum listesi";

            var values = await _commentService.GetByIdCommentAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto)
        {
            dto.Status = true;
            await _commentService.UpdateCommentAsync(dto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
    }
}
