using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Udemy.OcelotGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddAuthentication()
                .AddJwtBearer("OcelotAuthenticationSchemeKey", opt =>
                {
                    opt.Authority = builder.Configuration["IdentityServerUrl"];
                    opt.Audience = "ResourceOcelot";
                    opt.RequireHttpsMetadata = false;
                });

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("ocelot.json")
                .Build();

            builder.Services.AddOcelot(configuration);

            var app = builder.Build();

            app.UseHttpsRedirection();

            /* 🔴 EKSİK OLANLAR */
            app.UseAuthentication();
            app.UseAuthorization();

            /* Ocelot EN SON */
            app.UseOcelot();

            app.Run();

        }
    }
}
