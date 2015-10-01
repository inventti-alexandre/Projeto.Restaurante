using NUnit.Framework;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.MVC.AutoMapper;
using Projeto.Restaurante.MVC.Controllers;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtMesasController
    {
        private MesasController _controller;
        private readonly IAplicacaoMesa _aplicacao;

        public UtMesasController(IAplicacaoMesa aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new MesasController(_aplicacao);

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