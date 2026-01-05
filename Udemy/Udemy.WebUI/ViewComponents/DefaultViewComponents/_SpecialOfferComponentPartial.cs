using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
