using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
