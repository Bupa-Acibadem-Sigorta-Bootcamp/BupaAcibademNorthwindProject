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
using Microsoft.EntityFrameworkCore;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers;
using Northwind.DataAccessLayer.Abstract.IRepository;
using Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository;
using Northwind.DataAccessLayer.Concrete.EntityFramework.Context;
using Northwind.DataAccessLayer.Concrete.EntityFramework.EfRepository;
using Northwind.DataAccessLayer.Concrete.EntityFramework.UnitOfWorkRepository;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.WebApiLayer
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
            #region DependencyInjection

            #region JwtTokenService
            #endregion

            #region ApplicationContext
            services.AddDbContext<NorthwindContext>();
            services.AddScoped<DbContext, NorthwindContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            #endregion

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind.WebApiLayer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind.WebApiLayer v1"));
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
