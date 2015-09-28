using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Servicos.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.Servicos.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelPostItem, Item>();
        }
    }
}