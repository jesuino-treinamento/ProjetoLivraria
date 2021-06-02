using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OData.Swagger.Services;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProjetoLivraria.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddOData();

            services.AddOdataSwaggerSupport();

            services.AddSwaggerGen((config) =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Livraria - API",
                    Description = "API Livraria",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI((config) =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Livraria - API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });
        }
    }
}