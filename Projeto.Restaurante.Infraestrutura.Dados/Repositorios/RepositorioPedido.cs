using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IRepositorioPedido
    {
        #region Listar
        public IEnumerable<Pedido> Listar()
        {
            return Db.Pedidos.ToList();
        }
        #endregion
    }
}
