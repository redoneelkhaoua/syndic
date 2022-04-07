using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Vote
    {
        public Vote()
        {
            Choices = new HashSet<Choice>();
            Results = new HashSet<results>();
        }

        public int IdVote { get; set; }
        public string? Title { get; set; }
        public DateTime? creationDate { get; set; }
        public string? Type { get; set; }
        public int? IdCase { get; set; }

        public virtual Case? IdCaseNavigation { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<results> Results { get; set; }
    }
}
