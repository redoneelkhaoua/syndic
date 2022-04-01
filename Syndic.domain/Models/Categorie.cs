namespace Syndic.domain.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Dossiers = new HashSet<Dossier>();
        }

        public int IdCategorie { get; set; }
        public string? NomCategorie { get; set; }

        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
