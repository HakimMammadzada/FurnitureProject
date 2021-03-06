using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurnitureProject.Data;
using FurnitureProject.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FurnitureProject
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
            services.AddDbContext<FurnitureDbContext>(x=>x.UseSqlServer(Configuration["Connect:Db"]));
            services.AddIdentity<AppUser, IdentityRole<int>>()
                                         .AddDefaultTokenProviders()
                                          .AddEntityFrameworkStores<FurnitureDbContext>();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(20);
                options.Cookie.IsEssential = true;                                      
            });
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
            app.UseAuthorization();
            app.UseSession();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
