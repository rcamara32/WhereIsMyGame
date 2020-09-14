using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace WhereIsMyGame.API.Auth.Config
{
    public static class ApiDocumentation
    {

        public static void AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Where's My Game Auth API",
                    Description = "Where's My Game App",
                    Contact = new OpenApiContact() { Name ="Renan Camara", Email = "renan.camara@live.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });
        }

        public static void UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });
        }

    }
}
