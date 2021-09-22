using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Domain.Models;
using UrnaEletronica.Infra.Context;

namespace UrnaEletronica.Infra.Repository
{
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(UrnaEletronicaContext context) : base(context)
        {

        }
    }
}
