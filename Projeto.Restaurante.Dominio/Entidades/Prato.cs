namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Prato : Base
    {
        #region Propriedades
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }
        public bool Disponivel { get; private set; }
        public int CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        #endregion

        public override string ToString()
        {
            return Nome + " [" + Preco + "]";
        }

        #region Construtores
        //public Prato()
        //{

        //}

        //public Prato(string nome, decimal preco, string descricao, bool disponivel, int categoriaId)
        //{
        //    Nome = nome;
        //    Preco = preco;
        //    Descricao = descricao;
        //    Disponivel = disponivel;
        //    CategoriaId = categoriaId;
        //}

        //public Prato(int id, string nome, decimal preco, string descricao, bool disponivel, int categoriaId)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Preco = preco;
        //    Descricao = descricao;
        //    Disponivel = disponivel;
        //    CategoriaId = categoriaId;
        //}
        #endregion
    }
}

//Criar ViewModel para cada operação
//Configurar repositório
//Region em tudo
//Testes
// Serviços
//Async
//Tratar Exceptions