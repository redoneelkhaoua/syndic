using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Dossier
    {
        public Dossier()
        {
            Fichiers = new HashSet<Fichier>();
            Notes = new HashSet<Note>();
            Votes = new HashSet<Vote>();
        }

        public int IdDossier { get; set; }
        public string? Description { get; set; }
        public DateOnly? DateCreation { get; set; }
        public int? Categorie { get; set; }
        public int? Statut { get; set; }

        public virtual Categorie? CategorieNavigation { get; set; }
        public virtual Statut? StatutNavigation { get; set; }
        public virtual ICollection<Fichier> Fichiers { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
