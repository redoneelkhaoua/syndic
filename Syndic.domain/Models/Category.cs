namespace Syndic.domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Cases = new HashSet<Case>();
        }

        public int IdCategory { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
