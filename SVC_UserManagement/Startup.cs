using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationManagementDBEntity.Models;
using NotificationManagementDBEntity.Repositories;
using UserManagement.Helper;
using Microsoft.OpenApi.Models;
//using log4net.Repository.Hierarchy;
using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using UserManagement.Extensions;
using UserManagement.Athuentication_Demo;

namespace UserManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvcCore(
              config =>
              {

                  config.Filters.Add(typeof(CustomExceptionFilter));

              }
            );
            services.AddDbContext<NotificationDBContext>();
            services.AddTransient<IUserManagementHelper,UserManagementHelper>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "UserManagementAPI",
                    Description = "APS.NET core UserManagement WebApi",

                    Contact = new OpenApiContact
                    {
                        Name = "4BA-Batch",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/HamsithaNamburi/4BA-NotificationManagement.git"),
                    },

                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddAuthentication("Basic")

.AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);
            services.AddTransient<ICustomAuthenticationManager, CustomAuthenticationManager>();




        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
              
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
          
        }
    }
}
