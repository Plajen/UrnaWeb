using System;
using System.Linq.Expressions;
using UrnaEletronica.Application.Interfaces;

namespace UrnaEletronica.Application.Parameters
{
    public abstract class BaseParams<TEntity> : IBaseParams
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string OrderBy { get; set; }
        public abstract Expression<Func<TEntity, bool>> Filter();

        protected BaseParams() { }
    }
}
