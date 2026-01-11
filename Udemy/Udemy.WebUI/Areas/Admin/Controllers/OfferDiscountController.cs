using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.OfferDiscountDto;
using Udemy.WebUI.Services.CatalogServices.OfferDiscountservices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirimler listesi";

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }


        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {

            ViewBag.v0 = "İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirimler Girişi";
            return View();

        }

        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {

            ViewBag.v0 = "İndirim işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirimler Güncelle";

            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(dto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
