using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoPedido : IServicoBase<Pedido>
    {
        Pedido PedidoCorrente(int mesaId);
        IEnumerable<Pedido> GetAll(bool ativo);
    }
}
