using AutoMapper;
using Meta.Application.Commands;
using Meta.Application.Contracts;
using Meta.Application.ViewModel;
using Meta.Domain.Contracts.Repositories;
using Meta.Domain.Contracts.Services;
using Meta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meta.Application.Services
{
    public class ContatoApplicationService : IContatoApplicationService
    {
        private readonly IContatoDomainService _service;
        private readonly IContatoRepository _repository;
        private readonly IMapper _mapper;

        public ContatoApplicationService(IContatoDomainService service, IContatoRepository repository, IMapper mapper)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(ContatoCreateCommand command)
        {
            _service.Create(_mapper.Map<Contato>(command));
        }

        public void Update(ContatoUpdateCommand command)
        {
            _service.Update(_mapper.Map<Contato>(command));
        }

        public void Delete(ContatoDeleteCommand command)
        {
            _service.Delete(_mapper.Map<Contato>(command));
        }

        public List<ContatoViewModel> GetAll()
        {
            return _mapper.Map<List<ContatoViewModel>>(_repository.FindAll().Take(5));
        }

        public ContatoViewModel GetById(string id)
        {
            return _mapper.Map<ContatoViewModel>(_repository.FindById(Guid.Parse(id)));
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
