using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Syndic.Persistence.EntityFramework;

namespace Syndic.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSyndic(this IServiceCollection services)
        {
            //services.AddTransient<IRepository, RepositoryNpgsql>();
            // todo une connection par request => open à reception de request / fermeture une fois une reponse est donnée

            services.AddDbContext<SyndicContext>(o =>
            {
                o.UseNpgsql("User ID=postgres;Password=0000;Host=localhost;Port=5432;Database=Syndic;Pooling=true;Connection Lifetime=0;");
            });
            return services;
        }
    }
}