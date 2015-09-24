using System;
using Projeto.Restaurante.Dominio.Exceptions;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public abstract class Base
    {
        #region Propriedades
        public int Id { get; protected set; }
        public Guid GlobalId { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataUltimaAlteracao { get; protected set; }
        public bool Ativo { get; protected set; }
        #endregion

        #region Validações
        /// <exception cref="MyException">Id é obrigatório!</exception>
        public virtual void ValidarId()
        {
            if (this == null || Id <= 0)
                throw new MyException("Id é obrigatório!");
        }
        #endregion
    }
}
