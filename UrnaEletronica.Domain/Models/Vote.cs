
using System;
using UrnaEletronica.Domain.Core.Models;

namespace UrnaEletronica.Domain.Models
{
    public class Vote : Entity
    {
        public int CandidateId { get; private set; }
        public DateTime Voted { get; private set; }

        public Vote() { } // Empty constructor for EF

        public Vote(int id, int candidateId, DateTime voted)
        {
            Id = id;
            CandidateId = candidateId;
            Voted = voted;
        }
    }
}
