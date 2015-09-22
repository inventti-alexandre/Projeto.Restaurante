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

        #region Construtores

        #endregion
    }
}

//Criar ViewModel para cada operação
//Configurar repositório
//Region em tudo
//Testes
// Serviços
//Async