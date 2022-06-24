using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Avanade.IT.ChallengeSE.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.IT.ChallengeSE.CrossCuting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DbContext, DbTcContext>(sp => sp.GetService<DbTcContext>());
            services.AddScoped<DbTcContext>();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
        }
    }
}
