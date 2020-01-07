using AutoMapper;
using Meta.Application.Commands;
using Meta.Domain.Entities;
using System;

namespace Meta.Application.Profiles
{
    public class CommandToEntity : Profile
    {
        public CommandToEntity()
        {
            CreateMap<ContatoCreateCommand, Contato>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<ContatoUpdateCommand, Contato>();

            CreateMap<ContatoDeleteCommand, Contato>();
        }
    }
}