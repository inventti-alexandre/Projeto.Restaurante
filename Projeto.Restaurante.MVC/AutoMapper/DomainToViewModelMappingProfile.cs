using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels;

namespace Projeto.Restaurante.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelCategoria, Categoria>();
            Mapper.CreateMap<ViewModelItem, Item>();
            Mapper.CreateMap<ViewModelMesa, Mesa>();
            Mapper.CreateMap<ViewModelOpcao, Opcao>();
            Mapper.CreateMap<ViewModelPedido, Pedido>();
            Mapper.CreateMap<ViewModelPrato, Prato>();
        }
    }
}