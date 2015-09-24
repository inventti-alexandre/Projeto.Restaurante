using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoItem : IServicoBase<Item>
    {
        IEnumerable<Item> Listar(Pedido pedido);
    }
}
