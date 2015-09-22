using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Categoria : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        public virtual IList<Prato> Pratos { get; private set; }
        #endregion

        #region Construtores

        #endregion
    }
}