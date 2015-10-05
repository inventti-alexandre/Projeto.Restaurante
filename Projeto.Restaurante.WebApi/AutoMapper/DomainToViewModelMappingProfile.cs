using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.WebApi.ViewModels.Item;
using Projeto.Restaurante.WebApi.ViewModels.Opcao;
using Projeto.Restaurante.WebApi.ViewModels.Prato;

namespace Projeto.Restaurante.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Item, ViewModelGetItem>();
            Mapper.CreateMap<Opcao, ViewModelGetOpcao>();
            Mapper.CreateMap<Prato, ViewModelGetPrato>();
        }
    }
}