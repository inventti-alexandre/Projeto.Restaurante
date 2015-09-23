using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, ViewModelCategoria>();
            Mapper.CreateMap<Item, ViewModelItem>();

            Mapper.CreateMap<Mesa, ViewModelCreateMesa>();
            Mapper.CreateMap<Mesa, ViewModelDetailsMesa>();
            Mapper.CreateMap<Mesa, ViewModelEditMesa>();

            Mapper.CreateMap<Opcao, ViewModelOpcao>();
            Mapper.CreateMap<Pedido, ViewModelPedido>();
            Mapper.CreateMap<Prato, ViewModelPrato>();
        }
    }
}