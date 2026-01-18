using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Udemy.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Udemy.WebUI.Services.StatisticServices.CommentStatisticService;
using Udemy.WebUI.Services.StatisticServices.DiscountstatisticService;
using Udemy.WebUI.Services.StatisticServices.MessageStatisticService;
using Udemy.WebUI.Services.StatisticServices.UserStatisticService;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {

        private readonly ICatalogStatisticService _CatalogStatisticService;
        private readonly IUserStatisticService _userStatisticsService;
        private readonly ICommentStatisticService _commentStatiscticService;
        private readonly IDiscountstatisticService _discountstatisticService;
        private readonly IMessageStatisticService _messageStatisticService;


        public StatisticController(
            ICatalogStatisticService service,
            IUserStatisticService userStatisticsService,
            ICommentStatisticService commentStatiscticService, 
            IDiscountstatisticService discountstatisticService,
            IMessageStatisticService messageStatisticService
            )
        {
            _CatalogStatisticService = service;
            _userStatisticsService = userStatisticsService;
            _commentStatiscticService = commentStatiscticService;
            _discountstatisticService = discountstatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _CatalogStatisticService.GetBrandCount();
            var getProductCount = await _CatalogStatisticService.GetProductCount();
            var getCategoryCount = await _CatalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await _CatalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await _CatalogStatisticService.GetMinPriceProductName();
            //var getProductAvgPrice = await _service.GetProductAvgPrice()
            var getUserCount = await _userStatisticsService.GetUserCount();
            var TotalCommentCount = await _commentStatiscticService.TotalCommentCount();
            var ActiveCommentCount = await _commentStatiscticService.ActiveCommentCount();
            var PasiveCommentCount = await _commentStatiscticService.PasiveCommentCount();
            var GetDiscountCouponCount = await _discountstatisticService.GetDiscountCouponCount();
            var GetTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();



            ViewBag.getBrandCount = getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;
            //ViewBag.getProductAvgPrice = getProductAvgPrice;
            ViewBag.getUserCount = getUserCount;
            ViewBag.getTotalCommentCount = TotalCommentCount;
            ViewBag.GetActiveCommentCount = ActiveCommentCount;
            ViewBag.GetPasiveCommentCount = PasiveCommentCount;
            ViewBag.GetDiscountCouponCount = GetDiscountCouponCount;
            ViewBag.GetTotalMessageCount = GetTotalMessageCount;


            return View();
        }
    }
}
