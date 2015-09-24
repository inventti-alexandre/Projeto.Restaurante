using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioItem : IRepositorioBase<Item>
    {
        IEnumerable<Item> Listar(Pedido pedido);
    }
}
