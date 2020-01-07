using Meta.Domain.Contracts.Repositories;
using Meta.Domain.Contracts.Services;
using Meta.Domain.Entities;
using System;

namespace Meta.Domain.Services
{
    public class ContatoDomainService : BaseDomainService<Contato, Guid>, IContatoDomainService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ContatoDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.ContatoRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}