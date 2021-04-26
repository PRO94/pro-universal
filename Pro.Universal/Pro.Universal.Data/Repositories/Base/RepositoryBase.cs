using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pro.Universal.Data.DbContext;
using Pro.Universal.Data.Repositories.Interfaces.Base;

namespace Pro.Universal.Data.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public ProUniversalContext ProUniversalContext { get; set; }

        public RepositoryBase(ProUniversalContext proUniversalContext)
        {
            this.ProUniversalContext = proUniversalContext;
        }

        public IQueryable<T> FindAll()
        {
            return ProUniversalContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return ProUniversalContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            ProUniversalContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            ProUniversalContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            ProUniversalContext.Set<T>().Remove(entity);
        }
    }
}