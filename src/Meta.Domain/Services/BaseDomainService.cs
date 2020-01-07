using Meta.Domain.Contracts.Repositories;
using Meta.Domain.Contracts.Services;

namespace Meta.Domain.Services
{
    public abstract class BaseDomainService<TEntity, Tkey> : IBaseDomainService<TEntity, Tkey> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity, Tkey> _repository;

        protected BaseDomainService(IBaseRepository<TEntity, Tkey> repository)
        {
            this._repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
