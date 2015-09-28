namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Mesa : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        #endregion

        public override string ToString()
        {
            return Nome;
        }

        #region Construtores
        //public Mesa()
        //{
            
        //}

        //public Mesa(string nome)
        //{
        //    Nome = nome;
        //}

        //public Mesa(int id, string nome)
        //{
        //    Id = id;
        //    Nome = nome;
        //}
        #endregion
    }
}
