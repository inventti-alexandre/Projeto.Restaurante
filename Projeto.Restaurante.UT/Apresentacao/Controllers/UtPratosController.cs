using NUnit.Framework;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.MVC.AutoMapper;
using Projeto.Restaurante.MVC.Controllers;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtPratosController
    {
        private PratosController _controller;
        private readonly IAplicacaoPrato _aplicacaoPrato;
        private readonly IAplicacaoCategoria _aplicacaoCategoria;

        public UtPratosController(IAplicacaoPrato aplicacaoPrato, IAplicacaoCategoria aplicacaoCategoria)
        {
            _aplicacaoPrato = aplicacaoPrato;
            _aplicacaoCategoria = aplicacaoCategoria;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new PratosController(_aplicacaoPrato, _aplicacaoCategoria);

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
