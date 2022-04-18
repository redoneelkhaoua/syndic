using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Choice
    {
        public Choice()
        {
            Results = new HashSet<results>();
        }

        public int IdChoice { get; set; }
        public string? choice { get; set; }
        public int? IdVote { get; set; }

        public virtual Vote? IdVoteNavigation { get; set; }
        public virtual ICollection<results> Results { get; set; }
    }
}
