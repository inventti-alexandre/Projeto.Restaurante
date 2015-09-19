using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Item : Base
    {
        #region Propriedades
        public Pedido Pedido { get; private set; }
        public Prato Prato { get; private set; }
        public List<Opcao> Opcoes { get; private set; }
        #endregion

        #region Construtores

        #endregion

        #region Listar
        public static List<Item> Listar(Pedido pedido)
        {
            return new List<Item>();
        }
        #endregion
    }
}
