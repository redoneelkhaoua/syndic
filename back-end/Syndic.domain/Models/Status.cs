using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Status
    {
        public Status()
        {
            Cases = new HashSet<Case>();
        }

        public int IdStatus { get; set; }
        public string? statusName { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
