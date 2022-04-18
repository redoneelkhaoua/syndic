using System;
using System.Collections.Generic;

namespace Syndic.domain.Models
{
    public partial class results
    {
        public int IdVote { get; set; }
        public int IdParticipant { get; set; }
        public int? IdChoice { get; set; }

        public virtual Choice? IdChoiceNavigation { get; set; }
        public virtual Participant? IdParticipantNavigation { get; set; } = null!;
        public virtual Vote? IdVoteNavigation { get; set; } = null!;
    }
}
