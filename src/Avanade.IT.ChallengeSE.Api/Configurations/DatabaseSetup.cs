using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Avanade.IT.ChallengeSE.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DbTcContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure())
                .EnableDetailedErrors(environment.IsDevelopment())
                .EnableSensitiveDataLogging(environment.IsDevelopment())
                
            );
        }

        
        public static void UseDatabaseMigrate(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DbTcContext>().Database.Migrate();
            }
        }
    }
}
