using System;
using System.Collections.Generic;

namespace Meta.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> FindAll();
        TEntity FindById(TKey id);
        int Count();
    }
}
