using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UrnaEletronica.Domain.Core.Models;

namespace UrnaEletronica.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null,
            string orderBy = null,
            bool asNoTracking = true);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int? skip = null,
            int? take = null,
            string orderBy = null,
            bool asNoTracking = true);

        Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            bool asNoTracking = true);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity DeleteById(object id);
    }
}
