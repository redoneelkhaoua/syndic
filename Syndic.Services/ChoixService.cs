using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Services
{
    public class ChoixService : IService<Choix>
    {

        IRepository<Choix> _repository;
        public ChoixService(IRepository<Choix> repository)
        {
            _repository = repository;
        }


        public void creer(Choix model)
        {
            Guard.Against.Null(model, nameof(model));
            _repository.creer(model);
        }

        public void modifier(int id, Choix model)
        {

            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            _repository.modifier(id, model);
        }

        public Choix rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return _repository.rechercheParId(id);
        }

        public IEnumerable<Choix> rechercherTout()
        {
            return _repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            _repository.suprimer(id);
        }
    }
}
