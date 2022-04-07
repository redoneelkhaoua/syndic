using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
        static IConfiguration  configuration;

      

        public static IServiceCollection AddSyndic(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Fichier>, FichierRepository>();
            services.AddTransient<IService<Fichier>, FichierService>();
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IService<Note>, NoteService>();
            services.AddTransient<IRepository<Statut>, StatutRepository>();
            services.AddTransient<IService<Statut>, StatutService>();
            services.AddTransient<IRepository<Categorie>,CategorieRepository>();
            services.AddTransient<IService<Categorie>, CategorieService>();
            services.AddTransient<IRepository<Dossier>, DossierRepository>();
            services.AddTransient<IService<Dossier>, DossierService>();
            services.AddTransient<IService<Vote>, VoteService>();
            services.AddTransient<IRepository<Vote>, VoteRepository>();
            services.AddTransient<IService<Choix>, ChoixService>();
            services.AddTransient<IRepository<Choix>, ChoixRepository>();
            services.AddTransient<IService<Resultat>, ResultatService>();
            services.AddTransient<IRepository<Resultat>, ResultatRepository>();
            services.AddTransient<IService<Participant>, ParticipantService>();
            services.AddTransient<IRepository<Participant>, ParticipantRepository>();
            services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<SyndicContext>(o =>
            {
                o.UseNpgsql("User ID=postgres;Password=0000;Host=localhost;Port=5432;Database=Syndic;Pooling=true;Connection Lifetime=0;");
            });
            return services;
        }
    }
}