using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Fichier
    {
        public int IdFichier { get; set; }
        public string? Note { get; set; }
        public string? fichier { get; set; }

    

        public DateTime? DateCreation { get; set; }
        public string? Type { get; set; }
        public int? IdDossier { get; set; }

        public virtual Dossier? IdDossierNavigation { get; set; }
    }
}
