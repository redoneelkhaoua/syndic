﻿using Syndic.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Repository.Abstraction
{
    public interface IRepositoryDossier :IRepository<Dossier>
    {
        public IEnumerable<Dossier> rechercheParTitle(string title);
        public IEnumerable<Dossier> rechercheParCategorie(int id);
        public IEnumerable<Dossier> rechercheParStatut(int id);
    }
}
