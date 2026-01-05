using Microsoft.AspNetCore.Authentication.JwtBearer;
using Udemy.WebUI.Services;

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
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "MultiShopJwt";
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews();

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
