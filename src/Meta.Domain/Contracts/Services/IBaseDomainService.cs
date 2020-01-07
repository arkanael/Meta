using System;

namespace Meta.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity, TKey> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
     
    }
}
