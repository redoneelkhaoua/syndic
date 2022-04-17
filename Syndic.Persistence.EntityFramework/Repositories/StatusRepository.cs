
using Microsoft.EntityFrameworkCore;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
         SyndicContext context;

         public StatusRepository(SyndicContext context)
         {
             this.context = context;
         }

         public Status create(Status model)
         {
             model.IdStatus=context.Statues.Count()+1;
             context.Add(model);
             context.SaveChanges();
            return model;
         }

         public void update(int id, Status model)
         {
             var category = findById(id);
             
             category.statusName = model.statusName;

             context.SaveChanges();
         }

         public Status? findById(int id)
         {
             return context.Statues
                .Include(status => status.Cases).ThenInclude(dossier => dossier._files)
                .Include(status => status.Cases).ThenInclude(dossier => dossier.Notes)
                .Include(status => status.Cases).ThenInclude(dossier => dossier.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
                .Include(status => status.Cases).ThenInclude(dossier => dossier.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
                .Include(status => status.Cases).ThenInclude(dossier => dossier.Votes).ThenInclude(vote => vote.Choices)
                .Include(status => status.Cases).ThenInclude(dossier => dossier._files)
                .FirstOrDefault(s => s.IdStatus == id);
         }

         public IEnumerable<Status> getAll()
         {
             return context.Statues.Include(status => status.Cases).ThenInclude(_case => _case._files)
                .Include(status => status.Cases).ThenInclude(_case => _case.Notes)
                .Include(status => status.Cases).ThenInclude(_case => _case.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
                .Include(status => status.Cases).ThenInclude(_case => _case.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
                .Include(status => status.Cases).ThenInclude(_case => _case.Votes).ThenInclude(vote => vote.Choices)
                .Include(status => status.Cases).ThenInclude(_case => _case._files);
         }

         public void delete(int id)
         {
             context.Remove(findById(id));
             context.SaveChanges();
         }
     }
}
