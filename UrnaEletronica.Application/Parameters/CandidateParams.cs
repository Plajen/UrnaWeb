using LinqKit;
using System;
using System.Globalization;
using System.Linq.Expressions;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Application.Parameters
{
    public class CandidateParams : BaseParams<Candidate>
    {
        public string FullName { get; set; }
        public string ViceName { get; set; }
        public DateTime? Registered { get; set; }
        public int? Ticket { get; set; }

        public int Page { get; set; } = 1;
        public int TotalPages { get; private set; }

        public override Expression<Func<Candidate, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Candidate>();

            if (!string.IsNullOrEmpty(FullName))
            {
                predicate = predicate.And(x => x.FullName.ToLower().Contains(FullName.ToLower()));
            }

            if (!string.IsNullOrEmpty(ViceName))
            {
                predicate = predicate.And(x => x.ViceName.ToLower().Contains(ViceName.ToLower()));
            }

            if (Registered != null && Registered != new DateTime())
            {
                predicate = predicate
                    .And(x => x.Registered.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) == Registered.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }

            if (Ticket != null)
            {
                predicate = predicate.And(x => x.Ticket == Ticket);
            }

            return predicate;
        }

        public void CountPages(int take, int total)
        {
            TotalPages = decimal.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / Convert.ToDecimal(take)));
        }

        public CandidateParams() { }
    }
}
