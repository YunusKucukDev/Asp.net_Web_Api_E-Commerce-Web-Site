using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.DailySpecialOfferDto;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/DailySpecialOffer")]
    public class DailySpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DailySpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/DailySpecialOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDailySpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();
        }


        [Route("CreateDailySpecialOffer")]
        [HttpGet]
        public IActionResult CreateDailySpecialOffer()
        {

            ViewBag.v0 = "Kategori işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            return View();

        }

        [Route("CreateDailySpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateDailySpecialOffer(CreateDailySpecialOfferDto createDailySpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDailySpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/DailySpecialOffer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteDailySpecialOffer/{id}")]
        public async Task<IActionResult> DeleteDailySpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/DailySpecialOffer?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateDailySpecialOffer/{id}")]
        public async Task<IActionResult> UpdateDailySpecialOffer(string id)
        {

            ViewBag.v0 = "Kategori işlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelle";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/DailySpecialOffer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDailySpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateDailySpecialOffer/{id}")]
        public async Task<IActionResult> UpdateDailySpecialOffer(UpdateDailySpecialOfferDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/DailySpecialOffer/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DailySpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
