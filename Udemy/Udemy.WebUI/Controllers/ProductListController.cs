using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Udemy.Catalog.Services.ContactServices;
using Udemy.DtoLayer.CommnetDtos;
using Udemy.WebUI.Services.CommentServices;

namespace Udemy.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;

        public ProductListController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.x = id;
            

            var values = await _commentService.CommentListByProductId(id);
            return View(values); ;

        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            dto.ImageUrl = "test";
            dto.Rating = 1;
            dto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            dto.Status = false;

            

            await _commentService.GetAllCommentAsync();
            return RedirectToAction(
                         "ProductDetail",
                         "ProductList",
                         new { id = dto.ProductId }
                 );
        }
    }
}
