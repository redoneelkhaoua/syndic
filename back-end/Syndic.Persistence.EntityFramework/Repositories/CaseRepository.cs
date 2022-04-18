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
    public class CaseRepository : IRepository<Case>
    {
         SyndicContext context;
      

          public CaseRepository(SyndicContext context)
          {
              this.context = context;
              
          }

          public Case create(Case model)
          {
            

            model.creationDate = DateTime.Now;
            model.IdCase=context.Cases.Count()+1;
            
              context.Add(model);
       
               context.SaveChanges();
            return model;
          }

          public void update(int id, Case model)
          {
              var _case = findById(id);

              _case.Status = model.Status;
              _case.Category = model.Category;
              _case.creationDate = model.creationDate;
              _case.Description = model.Description;


              context.SaveChanges();
          }

          public Case? findById(int id)
          {
            return context.Cases.Include(dossier => dossier._files)
               .Include(cases => cases.Notes)
               .Include(_case => _case.CategoryNavigation)
               .Include(_case => _case.StatusNavigation)
               .Include(cases => cases.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
               .Include(cases => cases.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
               .Include(cases => cases.Votes).ThenInclude(vote => vote.Choices)
               .Include(cases => cases._files)
               .FirstOrDefault(s => s.IdCase == id);
        }

          public IEnumerable<Case> getAll()
        {
            return context.Cases
              .Include(_case => _case._files)
              .Include(_case => _case.Notes)
              .Include(_case => _case.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
              .Include(_case => _case.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
              .Include(_case => _case.Votes).ThenInclude(vote => vote.Choices)
              .Include(_case => _case._files)
              .Include(_case => _case.CategoryNavigation)
              .Include(_case => _case.StatusNavigation);
        }

          public void delete(int id)
          {
              context.Remove(findById(id));
              context.SaveChanges();
          }
     
      }
}
