using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Infra.Context;

namespace UrnaEletronica.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UrnaEletronicaContext _context;

        public UnitOfWork(UrnaEletronicaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
