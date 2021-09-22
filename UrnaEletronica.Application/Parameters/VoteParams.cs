using LinqKit;
using System;
using System.Globalization;
using System.Linq.Expressions;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Application.Parameters
{
    public class VoteParams : BaseParams<Vote>
    {
        public int? CandidateId { get; set; }
        public DateTime? Voted { get; set; }

        public int Page { get; set; } = 1;
        public int TotalPages { get; private set; }

        public override Expression<Func<Vote, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Vote>();

            if (CandidateId != null)
            {
                predicate = predicate.And(x => x.CandidateId == CandidateId);
            }

            if (Voted != null && Voted != new DateTime())
            {
                predicate = predicate
                    .And(x => x.Voted.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) == Voted.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }

            return predicate;
        }

        public void CountPages(int take, int total)
        {
            TotalPages = decimal.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(take)));
        }

        public VoteParams() { }
    }
}
