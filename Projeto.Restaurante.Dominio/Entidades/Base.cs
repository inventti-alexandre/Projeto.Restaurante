using System;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Base
    {
        #region Propriedades
        public int Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public bool Ativo { get; protected set; }
        #endregion

        #region Validações
        /// <exception cref="MyException"></exception>
        public virtual void ValidarId()
        {
            //if (this == null || Id <= 0)
            //throw new MyException("Id é obrigatório!");
        }
        #endregion
    }
}
