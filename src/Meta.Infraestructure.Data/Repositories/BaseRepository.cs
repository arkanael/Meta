using Meta.Domain.Contracts.Repositories;
using Meta.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meta.Infraestructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext _context)
        {
            this._context = _context;
        }

        public void Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity FindById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
