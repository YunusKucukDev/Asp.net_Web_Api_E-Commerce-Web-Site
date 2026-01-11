using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;
using Udemy.WebUI.Services.CatalogServices.DailySpecialOfferService;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/DailySpecialOffer")]
    public class DailySpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDailySpecialOfferService _dailySpecialOffer;

        public DailySpecialOfferController(IHttpClientFactory httpClientFactory, IDailySpecialOfferService dailySpecialOffer)
        {
            _httpClientFactory = httpClientFactory;
            _dailySpecialOffer = dailySpecialOffer;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Günlük İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Günlük indirimler";
            ViewBag.v3 = "Günlük indirimler listesi";

            var values = await _dailySpecialOffer.GetAllDailySpecialOfferAsync();
            return View(values);
        }


        [Route("CreateDailySpecialOffer")]
        [HttpGet]
        public IActionResult CreateDailySpecialOffer()
        {
            ViewBag.v0 = "Günlük İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Günlük indirimler";
            ViewBag.v3 = "Yeni Günlük indirimler Girişi";
            return View();
        }

        [Route("CreateDailySpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateDailySpecialOffer(CreateDailySpecialOfferDto createDailySpecialOfferDto)
        {
            await _dailySpecialOffer.CreateDailySpecialOfferAsync(createDailySpecialOfferDto);
            return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteDailySpecialOffer/{id}")]
        public async Task<IActionResult> DeleteDailySpecialOffer(string id)
        {
            await _dailySpecialOffer.DeleteDailySpecialOfferAsync(id);
            return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateDailySpecialOffer/{id}")]
        public async Task<IActionResult> UpdateDailySpecialOffer(string id)
        {
            ViewBag.v0 = "Günlük İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Günlük indirimler";
            ViewBag.v3 = "Günlük indirimler Silme işlemi";

            var values = await _dailySpecialOffer.GetByIdDailySpecialOfferAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateDailySpecialOffer/{id}")]
        public async Task<IActionResult> UpdateDailySpecialOffer(UpdateDailySpecialOfferDto dto)
        {
            await _dailySpecialOffer.UpdateDailySpecialOfferAsync(dto);
            return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
        }
    }
}
