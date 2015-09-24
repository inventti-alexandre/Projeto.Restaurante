using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.WebApi.ViewModels.Pratos;

namespace Projeto.Restaurante.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelGetPrato, Prato>();
        }
    }
}