using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoPedido : IAplicacaoBase<Pedido>
    {
        Pedido PedidoCorrente(int mesaId);
        IEnumerable<Pedido> GetAll(bool ativo);
    }
}
