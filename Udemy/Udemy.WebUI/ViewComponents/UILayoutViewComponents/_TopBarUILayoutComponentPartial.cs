using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Udemy.DtoLayer.CatalogDtos;
using Udemy.WebUI.Services.CatalogServices.AboutServices;

namespace Udemy.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _TopBarUILayoutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
