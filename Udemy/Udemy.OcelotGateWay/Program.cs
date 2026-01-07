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

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("OcelotAuthenticationSchemeKey",opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceOcelot";
            });


            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
            builder.Services.AddOcelot(configuration);




            var app = builder.Build();

            app.UseOcelot();

            app.MapGet("/", () => "Hello World!");
            
            app.Run();
        }
    }
}
