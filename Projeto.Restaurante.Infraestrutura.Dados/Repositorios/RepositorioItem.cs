using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioItem : RepositorioBase<Item> , IRepositorioItem
    {
        #region Listar
        public IEnumerable<Item> Listar(Pedido pedido)
        {
            return Db.Itens.Where(x => x.PedidoId == pedido.Id).ToList();
        }
        #endregion
    }
}
