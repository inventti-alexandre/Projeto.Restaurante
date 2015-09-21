using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoPedido : ServicoBase<Pedido>, IServicoPedido
    {
        private readonly IRepositorioPedido _repositorioPedido;

        public ServicoPedido(IRepositorioPedido repositorioPedido)
            : base(repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
    }
}
