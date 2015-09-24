using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoPedido : AplicacaoBase<Pedido>, IAplicacaoPedido
    {
        private readonly IServicoPedido _servicoPedido;

        public AplicacaoPedido(IServicoPedido servicoPedido)
            : base(servicoPedido)
        {
            _servicoPedido = servicoPedido;
        }

        public Pedido PedidoCorrente(Mesa mesa)
        {
            return _servicoPedido.PedidoCorrente(mesa);
        }
    }
}
