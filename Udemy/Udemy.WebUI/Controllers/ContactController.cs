
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.ContactDtos;
using Udemy.WebUI.Services.CatalogServices.ContactServices;

namespace Udemy.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IContactService _contactService;

        public ContactController(IHttpClientFactory httpClientFactory, IContactService contactService)
        {
            _httpClientFactory = httpClientFactory;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            dto.IsRead = false;
            dto.SendDate = DateTime.Now;
            

            await _contactService.GetAllContactAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
