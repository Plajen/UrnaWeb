using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UrnaEletronica.Domain.Core.Models;
using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Infra.Extensions;

namespace UrnaEletronica.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _context;
        private const int TakeMax = 100;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null,
            string orderBy = null,
            bool asNoTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                query = query.OrderBy(orderBy);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue && take.Value > 0)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var navigations = _context.Model.FindEntityType(typeof(TEntity))
                .GetDerivedTypesInclusive()
                .SelectMany(type => type.GetNavigations())
                .Distinct();

            foreach (var property in navigations)
                query = query.Include(property.Name);

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null,
            string orderBy = null,
            bool asNoTracking = true)
        {
            return await GetQueryable(filter, skip, take ?? TakeMax, orderBy ?? "Id DESC", asNoTracking).ToListAsync();
        }

        public virtual async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            bool asNoTracking = true)
        {
            var result = await GetQueryable(filter, null, null, null, asNoTracking).SingleOrDefaultAsync();
            return result;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }

        public TEntity Create(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entry = _context.Set<TEntity>().Update(entity);
            return entry.Entity;
        }

        public TEntity DeleteById(object id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
                return null;
            else
            {
                var dbSet = _context.Set<TEntity>();
                if (_context.Entry(entity).State == EntityState.Detached)
                    dbSet.Attach(entity);
                return dbSet.Remove(entity).Entity;
            }
        }
    }
}
