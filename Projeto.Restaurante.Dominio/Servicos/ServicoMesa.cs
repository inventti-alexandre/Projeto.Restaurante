using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoMesa : ServicoBase<Mesa>, IServicoMesa
    {
        private readonly IRepositorioMesa _repositorioMesa;

        public ServicoMesa(IRepositorioMesa repositorioMesa)
            : base(repositorioMesa)
        {
            _repositorioMesa = repositorioMesa;
        }
    }
}
