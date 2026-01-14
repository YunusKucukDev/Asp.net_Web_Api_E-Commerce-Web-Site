using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Udemy.IdentityServer.Settings;
using Udemy.WebUI.Handlers;
using Udemy.WebUI.Services.BasketServices;
using Udemy.WebUI.Services.CatalogServices.AboutServices;
using Udemy.WebUI.Services.CatalogServices.BrandServices;
using Udemy.WebUI.Services.CatalogServices.CategoryServices;
using Udemy.WebUI.Services.CatalogServices.ContactServices;
using Udemy.WebUI.Services.CatalogServices.DailySpecialOfferService;
using Udemy.WebUI.Services.CatalogServices.FeatureSliderServices;
using Udemy.WebUI.Services.CatalogServices.GeneralSpecialOfferServices;
using Udemy.WebUI.Services.CatalogServices.OfferDiscountservices;
using Udemy.WebUI.Services.CatalogServices.ProductDetailServices;
using Udemy.WebUI.Services.CatalogServices.ProductImagesServices;
using Udemy.WebUI.Services.CatalogServices.ProductServices;
using Udemy.WebUI.Services.CommentServices;
using Udemy.WebUI.Services.Concrete;
using Udemy.WebUI.Services.DiscountServices;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Settings;

namespace Udemy.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          

            builder.Services.AddAccessTokenManagement();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.ExpireTimeSpan = TimeSpan.FromDays(5);
                opt.Cookie.Name = "UdemyCookie";
                opt.SlidingExpiration = true;
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddHttpClient<IIdentityService, IdentityService>();

            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
            builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

            builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddScoped<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            builder.Services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(values.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}/");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}/");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IDailySpecialOfferService, DailySpecialOfferService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IGeneralSpecialOfferService, GeneralspecialOfferService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IAboutService, Aboutservice>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            

            builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
