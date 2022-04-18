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
    public class FileRepository : IRepository<file>
    {
        SyndicContext context;

        public FileRepository(SyndicContext context)
        {
            this.context = context;
        }

        public file create(file model)
        {
            model.creationDate = DateTime.Now;
            model.IdFile = context._files.Count() + 1;
            context.Add(model);
            context.SaveChanges();
            return model;
        }

        public void update(int id, file model)
        {
            var _file = findById(id);

            _file.IdCase = model.IdCase;
            _file.creationDate = model.creationDate;
            _file.Note=model.Note;
            _file._file = model._file;
            _file.Type = model.Type;



            context.SaveChanges();
        }

   

        public file? findById(int id)
        {
            return context._files
                .Include(fichier=>fichier.IdCaseNavigation)

                .FirstOrDefault(s => s.IdFile == id);
        }

        public IEnumerable<file> getAll()
        {
            return context._files.Include(fichier => fichier.IdCaseNavigation);
        }

        public void delete(int id)
        {
            context.Remove(findById(id));
            context.SaveChanges();
        }
    }
}
