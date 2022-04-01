﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        static IConfiguration  configuration;

      

        public static IServiceCollection AddSyndic(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryPublication<Fichier>, FichierRepository>();
            services.AddTransient<IServicePublication<Fichier>, FichierService>();
            services.AddTransient<IRepositoryPublication<Note>, NoteRepository>();
            services.AddTransient<IServicePublication<Note>, NoteService>();
            services.AddTransient<IRepository<Statut>, StatutRepository>();
            services.AddTransient<IService<Statut>, StatutService>();
            services.AddTransient<IRepository<Categorie>,CategorieRepository>();
            services.AddTransient<IService<Categorie>, CategorieService>();
            services.AddTransient<IRepositoryDossier, DossierRepository>();
            services.AddTransient<IServiceDossier, DossierService>();
            services.AddDbContext<SyndicContext>(o =>
            {
                o.UseNpgsql("User ID=postgres;Password=0000;Host=localhost;Port=5432;Database=Syndic2;Pooling=true;Connection Lifetime=0;");
            });
            return services;
        }
    }
}