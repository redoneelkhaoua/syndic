using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Vote
    {
        public Vote()
        {
            Choixes = new HashSet<Choix>();
            Resultats = new HashSet<Resultat>();
        }

        public int IdVote { get; set; }
        public string? Title { get; set; }
        public DateOnly? DateCreation { get; set; }
        public string? Typee { get; set; }
        public int? IdDossier { get; set; }

        public virtual Dossier? IdDossierNavigation { get; set; }
        public virtual ICollection<Choix> Choixes { get; set; }
        public virtual ICollection<Resultat> Resultats { get; set; }
    }
}
