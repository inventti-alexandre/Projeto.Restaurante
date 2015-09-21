using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoItem : ServicoBase<Item>, IServicoItem
    {
        private readonly IRepositorioItem _repositorioItem;

        public ServicoItem(IRepositorioItem repositorioItem)
            : base(repositorioItem)
        {
            _repositorioItem = repositorioItem;
        }
    }
}
