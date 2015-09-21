using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Item : Base
    {
        #region Propriedades
        public int PedidoId { get; private set; }
        public virtual Pedido Pedido { get; private set; }
        public int PratoId { get; private set; }
        public virtual Prato Prato { get; private set; }
        public virtual IList<Opcao> Opcoes { get; private set; }
        #endregion

        #region Construtores
        public Item()
        {
            
        }
        #endregion

        #region Listar
        public static IList<Item> Listar(Pedido pedido)
        {
            return new List<Item>();
        }
        #endregion
    }
}
