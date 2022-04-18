using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class file
    {
        public int IdFile { get; set; }
        public string? Note { get; set; }
        public string? _file { get; set; }

    

        public DateTime? creationDate { get; set; }
        public string? Type { get; set; }
        public int? IdCase { get; set; }

        public virtual Case? IdCaseNavigation { get; set; }
    }
}
