using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioPedido : IRepositorioBase<Pedido>
    {
        Pedido PedidoCorrente(Mesa mesa);
        bool ExistePedido(Mesa mesa);
    }
}
