using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Note
    {
        public int IdNote { get; set; }
        public string? note { get; set; }
        public DateTime? creationDate { get; set; }
        public string? Type { get; set; }
        public int? IdCase { get; set; }

        public virtual Case? IdCaseNavigation { get; set; }
    }
}
