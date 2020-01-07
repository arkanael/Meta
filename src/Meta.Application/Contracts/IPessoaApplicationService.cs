using Meta.Application.Commands;
using Meta.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Meta.Application.Contracts
{
    public interface IContatoApplicationService : IDisposable
    {
        void Create(ContatoCreateCommand command);
        void Update(ContatoUpdateCommand command);
        void Delete(ContatoDeleteCommand command);
        List<ContatoViewModel> GetAll();
        ContatoViewModel GetById(string id);
        int Count();
    }
}
