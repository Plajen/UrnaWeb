using System;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Domain.Core.Models;

namespace UrnaEletronica.Domain.Models
{
    public class Candidate : Entity
    {
        public string FullName { get; private set; }
        public string ViceName { get; private set; }
        public DateTime Registered { get; set; }
        public int Ticket { get; private set; }
        public int VotesQty => Votes != null ? Votes.Count() : 0;

        public virtual IEnumerable<Vote> Votes { get; private set; }

        public Candidate() { } // Empty constructor for EF

        public Candidate(int id, string fullName, string viceName, DateTime registered, int ticket)
        {
            Id = id;
            FullName = fullName;
            ViceName = viceName;
            Registered = registered;
            Ticket = ticket;
        }
    }
}
