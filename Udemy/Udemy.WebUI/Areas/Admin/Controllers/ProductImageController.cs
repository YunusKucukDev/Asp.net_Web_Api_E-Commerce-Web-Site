using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.ProductImagesDtos;
using Udemy.WebUI.Services.CatalogServices.ProductImagesServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {

            ViewBag.v0 = "Ürün Görsel işlemleri";
            ViewBag.v1 = "Ürünler";
            ViewBag.v2 = "Ürün Görsel Güncelleme sayfası";
            ViewBag.v3 = "Ürün Görsel İşlemleri";

            var values = await _productImageService.GetByProductIdProductsImageDtoAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(UpdateProductsImageDto dto)
        {
            await _productImageService.UpdateProductImageAsync(dto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

    }
}
