using Meta.Domain.Contracts.Repositories;
using Meta.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Meta.Infraestructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private IDbContextTransaction transaction;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null) transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction != null) transaction.Rollback();
        }

        public IContatoRepository ContatoRepository => new ContatoRepository(_context);
    }
}
