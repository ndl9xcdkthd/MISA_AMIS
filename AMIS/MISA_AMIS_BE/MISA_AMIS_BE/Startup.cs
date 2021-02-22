using AMIS.BL;
using AMIS.BL.Interfaces;
using AMIS.DAO;
using AMIS.DAO.Interfaces;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

namespace MISA_AMIS_BE
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA_AMIS_BE", Version = "v1" });
            });

            //Cau hinh base
            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));

            //Cau Hinh Database
            services.AddScoped(typeof(IDbConnector<>), typeof(DbConnector<>));

            //Employee
            services.AddScoped<IEmployeeDAO, EmployeeDAO>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();

            //Department
            services.AddScoped<IDepartmentDAO, DepartmentDAO>();
            services.AddScoped<IDepartmentBL, DepartmentBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA_AMIS_BE v1"));
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandle = context.Features.Get<IExceptionHandlerPathFeature>();
                var ex = exceptionHandle.Error;

                var err = new ErrorMsg();
                err.DevMsg = ex.Message;
                err.UserMsg = Common.Properties.Resources.ErrorException;

                await context.Response.WriteAsJsonAsync(err);
            }));

            app.UseCors("MyPolicy");

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
