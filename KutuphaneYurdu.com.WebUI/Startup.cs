using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KutuphaneYurdu.com.DAL.DbContexts;
using KutuphaneYurdu.com.BL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace KutuphaneYurdu.com.WebUI
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MSSQLDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CS1")));
            services.AddScoped(typeof(MSSQLRepo<>));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                opt.LoginPath = "/admin/giris";
                opt.LogoutPath = "/";

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseStatusCodePagesWithReExecute("/hata/{0}");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
            });

        }
    }
}
