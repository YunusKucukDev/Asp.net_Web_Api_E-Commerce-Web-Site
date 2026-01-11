using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.GeneralSpecialOfferDto;
using Udemy.WebUI.Services.CatalogServices.GeneralSpecialOfferServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/GeneralSpecialOffer")]
    public class GeneralSpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGeneralSpecialOfferService _GeneralSpecialOffer;

        public GeneralSpecialOfferController(IHttpClientFactory httpClientFactory, IGeneralSpecialOfferService GeneralSpecialOffer)
        {
            _httpClientFactory = httpClientFactory;
            _GeneralSpecialOffer = GeneralSpecialOffer;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Genel İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Genel indirimler";
            ViewBag.v3 = "Genel indirimler listesi";

            var values = await _GeneralSpecialOffer.GetAllGeneralSpecialOfferAsync();
            return View(values);
        }


        [Route("CreateGeneralSpecialOffer")]
        [HttpGet]
        public IActionResult CreateGeneralSpecialOffer()
        {
            ViewBag.v0 = "Genel İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Genel indirimler";
            ViewBag.v3 = "Yeni Genel indirimler Girişi";
            return View();
        }

        [Route("CreateGeneralSpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateGeneralSpecialOffer(CreateGeneralSpecialOfferDto createGeneralSpecialOfferDto)
        {
            await _GeneralSpecialOffer.CreateGeneralSpecialOfferAsync(createGeneralSpecialOfferDto);
            return RedirectToAction("Index", "GeneralSpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteGeneralSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteGeneralSpecialOffer(string id)
        {
            await _GeneralSpecialOffer.DeleteGeneralSpecialOfferAsync(id);
            return RedirectToAction("Index", "GeneralSpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateGeneralSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateGeneralSpecialOffer(string id)
        {
            ViewBag.v0 = "Genel İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Genel indirimler";
            ViewBag.v3 = "Genel indirimler Silme işlemi";

            var values = await _GeneralSpecialOffer.GetByIdGeneralSpecialOfferAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateGeneralSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateGeneralSpecialOffer(UpdateGeneralSpecialOfferDto dto)
        {
            await _GeneralSpecialOffer.UpdateGeneralSpecialOfferAsync(dto);
            return RedirectToAction("Index", "GeneralSpecialOffer", new { area = "Admin" });
        }
    }
}
