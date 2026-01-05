using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
