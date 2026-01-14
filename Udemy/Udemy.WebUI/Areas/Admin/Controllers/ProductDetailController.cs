using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.ProductDetailDtos;
using Udemy.WebUI.Services.CatalogServices.ProductDetailServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productdetailService;

        public ProductDetailController(IProductDetailService productdetailService)
        {
            _productdetailService = productdetailService;
        }

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {

            ViewBag.v0 = "Ürün Açıklama işlemleri";
            ViewBag.v1 = "ürün açıklaması";
            ViewBag.v2 = "Ürün açıklama Güncelleme sayfası";
            ViewBag.v3 = "Ürün açıklama İşlemleri";


            var values = await _productdetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
        {
            await _productdetailService.updateProductDetailAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

    }
}
