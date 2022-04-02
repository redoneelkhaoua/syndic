using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Choix
    {
        public Choix()
        {
            Resultats = new HashSet<Resultat>();
        }

        public int IdChoix { get; set; }
        public string? choix { get; set; }
        public int? IdVote { get; set; }

        public virtual Vote? IdVoteNavigation { get; set; }
        public virtual ICollection<Resultat> Resultats { get; set; }
    }
}
