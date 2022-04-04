using Syndic.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Service.Abstraction
{
    public interface IServiceChoix : IService<Choix>
    {
        public IEnumerable<Choix> rechercherParIdVote(int IdVote);
        public void suprimerToutParIdVote(int IdVote);
         }
}
