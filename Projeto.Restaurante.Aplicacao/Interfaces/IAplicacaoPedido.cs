using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoPedido : IAplicacaoBase<Pedido>
    {
        Pedido PedidoCorrente(Mesa mesa);
    }
}
