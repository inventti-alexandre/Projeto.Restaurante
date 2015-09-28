using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPedido : RepositorioBase<Pedido>, IRepositorioPedido
    {
        #region Pedido Corrente
        public Pedido PedidoCorrente(int mesaId)
        {
            return (from mesaDb in Db.Mesas
                    join pedidoDb in Db.Pedidos on mesaDb.Id equals pedidoDb.MesaId
                    where mesaDb.Id == mesaId && pedidoDb.Ativo
                    select pedidoDb).First();
        }
        #endregion

        #region Existe Pedido
        public bool ExistePedido(int mesaId)
        {
            var resultado = Convert.ToBoolean(from mesaDb in Db.Mesas
                                              join pedidoDb in Db.Pedidos on mesaDb.Id equals pedidoDb.MesaId
                                              where mesaDb.Id == mesaId && pedidoDb.Ativo
                                              select mesaId);
            return resultado;
        }

        public IEnumerable<Pedido> GetAll(bool ativo)
        {
            return Db.Pedidos.Where(x => x.Ativo == ativo).ToList();
        }
        #endregion
    }
}
