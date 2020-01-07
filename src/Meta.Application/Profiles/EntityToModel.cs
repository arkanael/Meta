using AutoMapper;
using Meta.Application.ViewModel;
using Meta.Domain.Entities;

namespace Meta.Application.Profiles
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Contato, ContatoViewModel>()
                .AfterMap((src, dest) => dest.Id = src.Id.ToString());
        }
    }
}
