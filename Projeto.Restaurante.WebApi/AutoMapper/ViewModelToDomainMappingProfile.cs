using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Item, ViewModelPostItem>();
        }
    }
}