using System.Collections.Generic;
using System.Linq;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Pedido : Base
    {
        #region Propriedades
        public int MesaId { get; private set; }
        public virtual Mesa Mesa { get; private set; }
        public virtual IList<Item> Itens { get; private set; }
        #endregion

        #region Construtores
        //public Pedido()
        //{
            
        //}
        #endregion

        #region Validações
        private bool ConstaItens()
        {
            return Itens.Any() && Itens.Select(x => x.Ativo).Any();
        }
        #endregion
        //Verificar se já consta pedido para mesa
        //Pedidos já foram entregues
        //valor da conta
    }
}
