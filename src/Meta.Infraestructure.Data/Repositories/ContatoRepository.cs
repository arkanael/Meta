using Meta.Domain.Contracts.Repositories;
using Meta.Domain.Entities;
using Meta.Infraestructure.Data.Context;
using System;

namespace Meta.Infraestructure.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato, Guid>, IContatoRepository
    {
        public ContatoRepository(DataContext _context) : base(_context)
        {

        }
    }
}
