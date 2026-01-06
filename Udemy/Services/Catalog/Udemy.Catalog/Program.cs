
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;
using Udemy.Catalog.Entities;
using Udemy.Catalog.Services.AboutServices;
using Udemy.Catalog.Services.BrandServices;
using Udemy.Catalog.Services.CategoryServices;
using Udemy.Catalog.Services.ContactServices;
using Udemy.Catalog.Services.DailyspecialOfferService;
using Udemy.Catalog.Services.FeatureSliderServices;
using Udemy.Catalog.Services.GenerealSpecialOfferService;
using Udemy.Catalog.Services.OfferDiscountService;
using Udemy.Catalog.Services.ProductDetailServices;
using Udemy.Catalog.Services.ProductImageServices;
using Udemy.Catalog.Services.ProductServices;
using Udemy.Catalog.settings;

namespace Udemy.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.Audience = "ResourceCatalog";

        options.RequireHttpsMetadata = false;

       
    });


            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();
            builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            builder.Services.AddScoped<IDailySpecialOfferService, DailySpecialOfferService>();
            builder.Services.AddScoped<IGeneralSpecialOfferService, GeneralSpecialOfferService>();
            builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IAboutServices, AboutServices>();
            builder.Services.AddScoped<IContactService, ContactService>();


            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

            builder.Services.AddSingleton<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
