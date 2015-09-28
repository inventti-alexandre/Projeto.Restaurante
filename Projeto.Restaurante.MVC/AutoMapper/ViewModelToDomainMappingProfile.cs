using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Categoria;
using Projeto.Restaurante.MVC.ViewModels.Mesa;
using Projeto.Restaurante.MVC.ViewModels.Opcao;
using Projeto.Restaurante.MVC.ViewModels.Pedido;
using Projeto.Restaurante.MVC.ViewModels.Prato;

namespace Projeto.Restaurante.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, ViewModelCreateCategoria>();
            Mapper.CreateMap<Categoria, ViewModelDetailsCategoria>();
            Mapper.CreateMap<Categoria, ViewModelEditCategoria>();

            Mapper.CreateMap<Mesa, ViewModelCreateMesa>();
            Mapper.CreateMap<Mesa, ViewModelDetailsMesa>();
            Mapper.CreateMap<Mesa, ViewModelEditMesa>();

            Mapper.CreateMap<Opcao, ViewModelCreateOpcao>();
            Mapper.CreateMap<Opcao, ViewModelDetailsOpcao>();
            Mapper.CreateMap<Opcao, ViewModelEditOpcao>();

            Mapper.CreateMap<Pedido, ViewModelCreatePedido>();
            Mapper.CreateMap<Pedido, ViewModelDetailsPedido>();
            Mapper.CreateMap<Pedido, ViewModelEditPedido>();

            Mapper.CreateMap<Prato, ViewModelCreatePrato>();
            Mapper.CreateMap<Prato, ViewModelDetailsPrato>();
            Mapper.CreateMap<Prato, ViewModelEditPrato>();
        }
    }
}