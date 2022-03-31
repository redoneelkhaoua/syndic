using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Syndic.domain.Models;
using Syndic.Persistence.EntityFramework;
using Syndic.Persistence.EntityFramework.Repositories;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;
using Syndic.Services;

namespace Syndic.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSyndic(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Categorie>,CategorieRepository>();
            services.AddTransient<IService<Categorie>, CategorieService>();
            // todo une connection par request => open à reception de request / fermeture une fois une reponse est donnée

            services.AddDbContext<SyndicContext>(o =>
            {
                o.UseNpgsql("User ID=postgres;Password=0000;Host=localhost;Port=5432;Database=Syndic;Pooling=true;Connection Lifetime=0;");
            });
            return services;
        }
    }
}