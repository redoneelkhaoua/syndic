using Syndic.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Repository.Abstraction
{
    public interface IRepositoryChoix:IRepository<Choix>
    {
        public IEnumerable<Choix> rechercherParIdVote(int IdVote);
        public void suprimerToutParIdVote(int IdVote);

    }
}
