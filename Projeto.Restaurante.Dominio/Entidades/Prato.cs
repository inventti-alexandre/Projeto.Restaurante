using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Prato : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }
        public virtual List<Categoria> Categorias { get; private set; }
        #endregion

        #region Construtores
       
        #endregion

        #region Listar
        public static List<Prato> Listar(Categoria categoria)
        {
            return new List<Prato>();
        }
        #endregion
    }
}
