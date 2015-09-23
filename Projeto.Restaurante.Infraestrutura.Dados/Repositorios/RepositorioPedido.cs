using System;
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

        #region Pedido Corrente
        public Pedido PedidoCorrente(Mesa mesa)
        {
            return (from mesaDb in Db.Mesas
                    join pedidoDb in Db.Pedidos on mesaDb.Id equals pedidoDb.MesaId
                    where mesaDb.Id == mesa.Id && pedidoDb.Ativo
                    select pedidoDb).First();
        }
        #endregion

        #region Existe Pedido
        public bool ExistePedido(Mesa mesa)
        {
            var resultado = Convert.ToBoolean(from mesaDb in Db.Mesas
                                              join pedidoDb in Db.Pedidos on mesaDb.Id equals pedidoDb.MesaId
                                              where mesaDb.Id == mesa.Id && pedidoDb.Ativo
                                              select mesa.Id);
            return resultado;
        }
        #endregion
    }
}
