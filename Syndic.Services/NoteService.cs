﻿using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;


namespace Syndic.Services
{
    public class NoteService : IService<Note>
    {
        IRepository<Note> repository;

        public NoteService(IRepository<Note> repository)
        {
            this.repository = repository;
        }
      

        public void create(Note model)
        {
            Guard.Against.Null(model, nameof(model));
            repository.create(model);
        }

        public void update(int id, Note model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.update(id, model);
        }

    

        public Note findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.findById(id);
        }

        public IEnumerable<Note> getAll()
        {
            return repository.getAll();
        }

        public void delete(int id)
        {
            repository.delete(id);
        }

    }
}
