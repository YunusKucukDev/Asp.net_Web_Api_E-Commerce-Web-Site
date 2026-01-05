
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.BusinessLayer.concrete;
using Udemy.Cargo.DataAccessLayer.Abstaction;
using Udemy.Cargo.DataAccessLayer.Concrete;
using Udemy.Cargo.DataAccessLayer.EntityFreamwork;

namespace Udemy.Cargo.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.RequireHttpsMetadata = false;
                opt.Audience = "ResourceCargo";
            });


            builder.Services.AddDbContext<CargoContex>();

            builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();

            builder.Services.AddScoped<ICargoCompanyservice, CargoCompanyManager>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
           

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
