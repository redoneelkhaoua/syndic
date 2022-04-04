﻿using Ardalis.GuardClauses;
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
    public class FichierService : IServicePublication<Fichier>
    {
        IRepositoryPublication<Fichier> repository;

        public FichierService(IRepositoryPublication<Fichier> repository)
        {
            this.repository = repository;
        }

        public void creer(Fichier model)
        {
            Guard.Against.Null(model, nameof(model));
            repository.creer(model);
        }

        public void modifier(int id, Fichier model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.modifier(id, model);
        }

        public IEnumerable<Fichier> rechercheParDossier(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParDossier(id);
        }

        public Fichier rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParId(id);
        }

        public IEnumerable<Fichier> rechercherTout()
        {
            return repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            repository.suprimer(id);
        }
    }
}