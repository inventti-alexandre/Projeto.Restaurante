using System.Collections.Generic;

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

        #endregion
        //Verificar se já consta pedido para mesa
        //Pedidos já foram entregues
        //valor da conta
    }
}
