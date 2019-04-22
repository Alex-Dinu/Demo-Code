using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Shared
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "Demo", Version = "v1.0", Description = GetMainTitle() });

                //c.IncludeXmlComments("C:\\dev\\Bitbucket\\webscv\\Fortellis\\CaseManagement\\CaseManagement.Service\\obj\\Debug\\netcoreapp2.1\\CaseManagement.Service.xml");
                //c.IncludeXmlComments("C:\\Dev\\Bitbucket\\webscv\\Fortellis\\CaseManagement\\CaseManagement.Application\\obj\\Debug\\netcoreapp2.1\\CaseManagement.Application.xml");
                c.EnableAnnotations();
            });

            return services;
        }

        private static string GetMainTitle()
        {
            string title = string.Empty;
            title += " # Demo \n\n";

            return title;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");

                c.DocumentTitle = GetMainTitle();
                c.DocExpansion(DocExpansion.None);

            });

            return app;
        }
    }

}
