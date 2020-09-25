using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.ApplicationServices.Services;
using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using PetShopApp2020.Infrastructure.Data;
using PetShopApp2020.Infrastructure.Data.Repositories;

namespace PetShop2020.RestAPI
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
        
            services.AddDbContext<PetShopAppContext>(
                opt => opt.UseSqlite("Data Source=PetShop2020.db"));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeRepository, TypeRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetService, PetServices>();
            services.AddScoped<IPetTypes, TypeService>();
            services.AddScoped<IOwnerService, OwnerService>();

           
           services.AddControllers().AddNewtonsoftJson(o =>
           {
               o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               o.SerializerSettings.MaxDepth = 5;
           });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Pet SHop API",
                        Description = "The dok for Pet Shop API",
                        Version = "v2"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();

                   // ctx.Database.EnsureCreated();

                }
            }
            else
            {
                app.UseHsts();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
               options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Shop API");
                options.RoutePrefix = "";
            });
           


        }
    }
}
