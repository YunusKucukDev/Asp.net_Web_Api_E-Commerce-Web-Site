using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Udemy.IdentityServer.Settings;
using Udemy.WebUI.Handlers;
using Udemy.WebUI.Services.Concrete;
using Udemy.WebUI.Services.Interfaces;
using Udemy.WebUI.Settings;

namespace Udemy.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.LogoutPath = "/Login/Logout";
                opt.AccessDeniedPath = "/Pages/AccesDenied";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "MultiShopJwt";
            });

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

            var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
            builder.Services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(values.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

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
                pattern: "{controller=Login}/{action=SignIn}/{id?}"
            );

            app.Run();
        }
    }
}
