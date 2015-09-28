using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioItem : RepositorioBase<Item> , IRepositorioItem
    {
        #region GetAll
        public IEnumerable<Item> GetAll(bool ativo)
        {
            return Db.Itens.Where(x => x.Ativo == ativo).ToList();
        }

        public IEnumerable<Item> GetAll(int pedidoId)
        {
            return Db.Itens.Where(x => x.PedidoId == pedidoId).ToList();
        }

        public IEnumerable<Item> GetAll(int pedidoId, bool ativo)
        {
            return Db.Itens.Where(x => x.PedidoId == pedidoId && x.Ativo == ativo).ToList();
        }
        #endregion
    }
}
