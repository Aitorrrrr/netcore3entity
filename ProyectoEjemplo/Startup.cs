using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoEjemplo.Data;
using ProyectoEjemplo.Helpers;
using ProyectoEjemplo.Middlewares;
using ProyectoEjemplo.Registers;
using System;

namespace ProyectoEjemplo
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            //services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("ProyEjemploDB"));
            services.AddDbContext<DataContext>(x => x.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection")));

            services.AddControllers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                });

            services.addCustomRegisters();
            services.addSwaggersRegisters();

            var mappingConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("middle 1 entra");
            //    //await next.Invoke();

            //    Console.WriteLine("middle 1 sale");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("middle 2 entra");
            //    await next.Invoke();

            //    Console.WriteLine("middle 2 sale");
            //});

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "API proyecto ejemplo");
                opt.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt => opt.AllowAnyOrigin()
                                  .AllowAnyMethod() 
                                  .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}