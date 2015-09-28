using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Servicos.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.Servicos.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Item, ViewModelPostItem>();
        }
    }
}