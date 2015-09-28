using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioPedido : IRepositorioBase<Pedido>
    {
        Pedido PedidoCorrente(int mesaId);
        bool ExistePedido(int mesaId);
        IEnumerable<Pedido> GetAll(bool ativo);
    }
}
