using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Domain.Models;
using UrnaEletronica.Infra.Context;

namespace UrnaEletronica.Infra.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(UrnaEletronicaContext context) : base(context)
        {

        }
    }
}
