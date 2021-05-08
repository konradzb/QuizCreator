using Cars.DTOs;
using Cars.Repo;
using Cars.Repositories;
using Cars.Repositories.FuelType;
using Cars.Service;
using Cars.Service.Employee;
using Cars.Service.FuelType;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars
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
            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<ICarDao, FakeCarDao>();

            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<IBrandDao, FakeBrandDao>();

            services.AddSingleton<ICarRentalService, CarRentalService>();
            services.AddSingleton<ICarRentalDao, FakeCarRentalDao>();

            services.AddSingleton<IModelService, ModelService>();
            services.AddSingleton<IModelDao, FakeModelDao>();

            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeDao, FakeEmployeeDao>();

            services.AddSingleton<IFuelTypeService, FuelTypeService>();
            services.AddSingleton<IFuelTypeDao, FakeFuelTypeDao>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
