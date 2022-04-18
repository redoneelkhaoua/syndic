using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class Participant
    {
        public Participant()
        {
            Results = new HashSet<results>();
        }

        public int IdParticipant { get; set; }
        public string? participantName { get; set; }

        public virtual ICollection<results> Results { get; set; }
    }
}
