using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.WebApi.ViewModels.Item;
using Projeto.Restaurante.WebApi.ViewModels.Opcao;
using Projeto.Restaurante.WebApi.ViewModels.Pedido;
using Projeto.Restaurante.WebApi.ViewModels.Prato;

namespace Projeto.Restaurante.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelPostItem, Item>();
            Mapper.CreateMap<ViewModelPostOpcao, Opcao>();
            Mapper.CreateMap<ViewModelPostPedido, Pedido>();
            Mapper.CreateMap<ViewModelPostPrato, Prato>();
        }
    }
}