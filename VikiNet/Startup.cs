using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VikiNet.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VikiNet.Models;
using VikiNet.Data.Concrete;
using VikiNet.Data.Abstract;
using Microsoft.AspNetCore.Http;

namespace VikiNet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VikiNetDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("default")));

            services.AddScoped<ISubjectService, SubjectService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<VikiNetDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });




            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.HttpOnly = true;
                //option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                //option.Cookie.Expiration = TimeSpan.FromDays(30);
                //account.google.com
                //google.com
                //gmail.com
                //youtube.com
            });



            services.AddDistributedMemoryCache();

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}