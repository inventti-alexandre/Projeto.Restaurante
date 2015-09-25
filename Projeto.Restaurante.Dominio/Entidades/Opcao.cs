namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Opcao : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        #endregion

        #region Construtores
        public Opcao()
        {

        }

        public Opcao(string nome)
        {
            Nome = nome;
        }

        public Opcao(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        #endregion
    }
}