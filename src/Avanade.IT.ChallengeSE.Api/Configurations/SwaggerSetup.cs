using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Avanade.IT.ChallengeSE.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));



            services.AddSwaggerGen(s =>
            {
                s.DescribeAllParametersInCamelCase();
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Project Internal Talent SE",
                    Description = "Project of Questions and Answers",
                    Contact = new OpenApiContact { Name = "Fernando Henrique", Email = "fernando.guerra@corujasdev.com.br", Url = new Uri("http://www.corujas.dev") },
                });

                s.CustomSchemaIds(type => type.ToString());
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Microsoft Mvps");
                options.RoutePrefix = string.Empty;
            });

            app.UseSwagger();
        }
    }
}
