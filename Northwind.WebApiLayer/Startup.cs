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
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfiguration =>
            {
                cfiguration.SaveToken = true;
                cfiguration.RequireHttpsMetadata = false;

                cfiguration.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    RoleClaimType = "Roles",
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Issuer"],//Configuration["Tokens:Audience"] bende token service ile token clientler aynı olduğundan Issuer key'ini kullandım
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            #endregion

            #region ApplicationContext
            //TODO : Veri tabanı baðlantısı default di çözümü(bağlantı adresi contexte tutuluyor.)

            /* services.AddDbContext<NorthwindContext>();
            services.AddScoped<DbContext, NorthwindContext>(); */

            //TODO : Veri tabanı baðlantısı di çözümü(bağlantı adresi appsettings.json'da tutuluyor. Migration oluşturmak istediğimizde nerede olacağını söyledik.)
            services.AddScoped<DbContext, NorthwindContext>();
            services.AddDbContext<NorthwindContext>(DbContextOptionsBuilder =>
            {
                DbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                    SqlServerDbContextOptionsBuilder =>
                    {
                        SqlServerDbContextOptionsBuilder.MigrationsAssembly("Northwind.DataAccessLayer");
                    });
            });

            #endregion

            #region ServiceSection
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IUserService, UserManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<IOrderRepository, EfOrderRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            #endregion

            #region Cores Settings
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    builder => builder
                    .WithOrigins("www.api.com")
                    .AllowAnyOrigin()
                    .WithMethods("GET","POST")
                    .AllowAnyMethod()
                    .WithHeaders("accept","content-type")
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
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
