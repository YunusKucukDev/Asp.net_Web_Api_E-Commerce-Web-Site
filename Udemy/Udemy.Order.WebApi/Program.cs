
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Udemy.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Application.Services;
using Udemy.Order.Persistence.Contex;
using Udemy.Order.Persistence.Repositories;
namespace Udemy.Order.WebApi
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
                opt.Audience = "ResourceOrder";
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddAplicationServices(builder.Configuration);
            builder.Services.AddDbContext<OrderContex>();
            #region
            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<CreateAddressComandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();

            builder.Services.AddScoped<GetOrderDetailQueryCommandHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryCommandHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            #endregion


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
