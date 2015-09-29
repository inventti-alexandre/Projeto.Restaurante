using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelPostItem, Item>();
        }
    }
}