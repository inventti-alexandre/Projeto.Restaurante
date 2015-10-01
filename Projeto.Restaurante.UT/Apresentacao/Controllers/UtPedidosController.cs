using NUnit.Framework;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.MVC.AutoMapper;
using Projeto.Restaurante.MVC.Controllers;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtPedidosController
    {
        private PedidosController _controller;
        private readonly IAplicacaoPedido _aplicacaoPedido;
        private readonly IAplicacaoMesa _aplicacaoMesa;
        private readonly IAplicacaoCategoria _aplicacaoCategoria;
        private readonly IAplicacaoPrato _aplicacaoPrato;
        private readonly IAplicacaoOpcao _aplicacaoOpcao;

        public UtPedidosController(IAplicacaoPedido aplicacaoPedido, IAplicacaoMesa aplicacaoMesa, IAplicacaoCategoria aplicacaoCategoria, IAplicacaoPrato aplicacaoPrato, IAplicacaoOpcao aplicacaoOpcao)
        {
            _aplicacaoPedido = aplicacaoPedido;
            _aplicacaoMesa = aplicacaoMesa;
            _aplicacaoCategoria = aplicacaoCategoria;
            _aplicacaoPrato = aplicacaoPrato;
            _aplicacaoOpcao = aplicacaoOpcao;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new PedidosController(_aplicacaoPedido, _aplicacaoMesa, _aplicacaoCategoria, _aplicacaoPrato, _aplicacaoOpcao);

            AutoMapperConfig.RegisterMappings();
        }

        [Test]
        public void Index()
        {
            var view = _controller.Index();
            Assert.IsNotNull(view);
        }
    }
}
