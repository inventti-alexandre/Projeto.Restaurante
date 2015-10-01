using NUnit.Framework;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.MVC.AutoMapper;
using Projeto.Restaurante.MVC.Controllers;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtOpcoesController
    {
        private OpcoesController _controller;
        private readonly IAplicacaoOpcao _aplicacao;

        public UtOpcoesController(IAplicacaoOpcao aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new OpcoesController(_aplicacao);

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
