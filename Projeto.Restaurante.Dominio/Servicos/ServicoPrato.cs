using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoPrato : ServicoBase<Prato>, IServicoPrato
    {
        private readonly IRepositorioPrato _repositorioPrato;

        public ServicoPrato(IRepositorioPrato repositorioPrato)
            : base(repositorioPrato)
        {
            _repositorioPrato = repositorioPrato;
        }
    }
}
