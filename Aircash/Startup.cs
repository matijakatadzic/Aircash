using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aircash.Business;
using Aircash.Business.Settings;
using Aircash.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aircash
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
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));

            var appSettings = this.Configuration.Get<AppSettings>();
            services.AddMainEntities(appSettings);
            services.AddRepositories();
            services.AddCustomHttpClient(appSettings);
            services.AddBusiness();

            services.AddMvc();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(appSettings.SwaggerOptions.Name,
                 new Microsoft.OpenApi.Models.OpenApiInfo { Title = appSettings.SwaggerOptions.Title, Version = appSettings.SwaggerOptions.Version });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            var appSettings = this.Configuration.Get<AppSettings>();
            app.UseSwaggerUI(options => options.SwaggerEndpoint(appSettings.SwaggerOptions.Url,
                appSettings.SwaggerOptions.EndpointName)
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
