using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Categoria;
using Projeto.Restaurante.MVC.ViewModels.Mesa;
using Projeto.Restaurante.MVC.ViewModels.Opcao;
using Projeto.Restaurante.MVC.ViewModels.Pedido;
using Projeto.Restaurante.MVC.ViewModels.Prato;

namespace Projeto.Restaurante.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ViewModelCreateCategoria, Categoria>();
            Mapper.CreateMap<ViewModelDetailsCategoria, Categoria>();
            Mapper.CreateMap<ViewModelEditCategoria, Categoria>();

            Mapper.CreateMap<ViewModelCreateMesa, Mesa>();
            Mapper.CreateMap<ViewModelDetailsMesa, Mesa>();
            Mapper.CreateMap<ViewModelEditMesa, Mesa>();

            Mapper.CreateMap<ViewModelCreateOpcao, Opcao>();
            Mapper.CreateMap<ViewModelDetailsOpcao, Opcao>();
            Mapper.CreateMap<ViewModelEditOpcao, Opcao>();

            Mapper.CreateMap<ViewModelCreatePedido, Pedido>();
            Mapper.CreateMap<ViewModelDetailsPedido, Pedido>();
            Mapper.CreateMap<ViewModelEditPedido, Pedido>();

            Mapper.CreateMap<ViewModelCreatePrato, Prato>();
            Mapper.CreateMap<ViewModelDetailsPrato, Prato>();
            Mapper.CreateMap<ViewModelEditPrato, Prato>();
        }
    }
}