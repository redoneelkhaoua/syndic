using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Case
    {
        public object files;

        public Case()
        {
            _files = new HashSet<file>();
            Notes = new HashSet<Note>();
            Votes = new HashSet<Vote>();
        }

        public int IdCase { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? creationDate { get; set; }
        public int? Category { get; set; }
        public int? Status { get; set; }

        public virtual Category? CategoryNavigation { get; set; }
        public virtual Status? StatusNavigation { get; set; }
        public virtual ICollection<file> _files { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
