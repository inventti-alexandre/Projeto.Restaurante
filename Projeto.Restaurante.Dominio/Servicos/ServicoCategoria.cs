using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoCategoria : ServicoBase<Categoria>, IServicoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
            : base(repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }
    }
}
