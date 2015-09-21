using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoOpcao : ServicoBase<Opcao>, IServicoOpcao
    {
        private readonly IRepositorioOpcao _repositorioOpcao;

        public ServicoOpcao(IRepositorioOpcao repositorioOpcao)
            : base(repositorioOpcao)
        {
            _repositorioOpcao = repositorioOpcao;
        }
    }
}
