using System.Collections.Generic;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Categoria : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        public virtual IList<Prato> Pratos { get; private set; }
        #endregion

        public override string ToString()
        {
            return Nome;
        }

        #region Construtores
        //public Categoria()
        //{

        //}
        //public Categoria(string nome)
        //{
        //    Nome = nome;
        //}
        //public Categoria(int id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}
        #endregion
    }
}