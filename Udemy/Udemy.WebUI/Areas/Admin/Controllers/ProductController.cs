using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Udemy.DtoLayer.CatalogDtos.CategoryDtos;
using Udemy.DtoLayer.CatalogDtos.ProductDtos;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using Udemy.WebUI.Services.CatalogServices.ProductServices;

namespace Udemy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
           
            _productService = productService;
            _categoryService = categoryService;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün listesi";
            await GetCategoriesInProducts();

            var values = await _productService.GetAllProductAsync();

            return View(values);

        }

        [Route("ProductListWithCategory/{id}")]
        public async Task<IActionResult> ProductListWithCategory(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün listesi";

            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }


        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün listesi";
            await GetCategoriesInProducts();

            return View();

        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }


        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }


        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelle";

            await GetCategoriesInProducts();

            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
        }




        private async Task GetCategoriesInProducts()
        {
            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
        }
    }
}
