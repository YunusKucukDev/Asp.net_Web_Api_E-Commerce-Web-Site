using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.FeatureSliderDto;
using Udemy.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Öne Çıkan Slider Görsel işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Öne çıkan görsel  listesi";

            var values = await _featureSliderService.GetAllFeatureslider();
            return View(values);
        }


        [Route("CreateFeatureSlider")]
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {

            ViewBag.v0 = "Öne Çıkan Slider Görsel işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Öne çıkan görsel  listesi";
            return View();

        }

        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {

            ViewBag.v0 = "Öne Çıkan Slider Görsel işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne çıkan görseller";
            ViewBag.v3 = "Öne çıkan görsel  listesi";

            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
