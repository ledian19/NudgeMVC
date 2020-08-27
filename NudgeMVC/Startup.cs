using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NudgeMVC.Data;

namespace NudgeMVC {
    public class Startup {

        public Startup (IConfiguration configuration) {
            this.configuration = configuration;

        }
        public IConfiguration configuration { get; }

        public Startup (Microsoft.AspNetCore.Hosting.IWebHostEnvironment env) {
            using (var client = new NudgeContext ()) {
                client.Database.EnsureCreated ();
            }

        }

        public void ConfigureServices (IServiceCollection services) {
            services.AddControllersWithViews ();
            
            services.AddMvc ();
            services.AddEntityFrameworkSqlite ().AddDbContext<NudgeContext> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}