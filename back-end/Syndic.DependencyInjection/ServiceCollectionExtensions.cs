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
            services.AddTransient<IRepository<file>, FileRepository>();
            services.AddTransient<IService<file>, FileService>();
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IService<Note>, NoteService>();
            services.AddTransient<IRepository<Status>, StatusRepository>();
            services.AddTransient<IService<Status>, StatusService>();
            services.AddTransient<IRepository<Category>,CategoryRepository>();
            services.AddTransient<IService<Category>, CategoryService>();
            services.AddTransient<IRepository<Case>, CaseRepository>();
            services.AddTransient<IService<Case>, CaseService>();
            services.AddTransient<IService<Vote>, VoteService>();
            services.AddTransient<IRepository<Vote>, VoteRepository>();
            services.AddTransient<IService<Choice>, ChoiceService>();
            services.AddTransient<IRepository<Choice>, ChoiceRepository>();
            services.AddTransient<IService<results>, resultsService>();
            services.AddTransient<IRepository<results>, resultsRepository>();
            services.AddTransient<IService<Participant>, ParticipantService>();
            services.AddTransient<IRepository<Participant>, ParticipantRepository>();
            services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });



            


            return services;
        }
    }
}