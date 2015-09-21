using AutoMapper;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels;

namespace Projeto.Restaurante.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, ViewModelCategoria>();
            Mapper.CreateMap<Item, ViewModelItem>();
            Mapper.CreateMap<Mesa, ViewModelMesa>();
            Mapper.CreateMap<Opcao, ViewModelOpcao>();
            Mapper.CreateMap<Pedido, ViewModelPedido>();
            Mapper.CreateMap<Prato, ViewModelPrato>();
        }
    }
}