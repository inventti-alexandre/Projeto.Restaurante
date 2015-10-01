using NUnit.Framework;
using Projeto.Restaurante.Aplicacao;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;
using Projeto.Restaurante.Dominio.Servicos;
using Projeto.Restaurante.Infraestrutura.Dados.Repositorios;
using Projeto.Restaurante.MVC.AutoMapper;
using Projeto.Restaurante.MVC.Controllers;
using Projeto.Restaurante.MVC.ViewModels.Categoria;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtCategoriasController
    {
        private CategoriasController _controller;
        private readonly IAplicacaoCategoria _aplicacao;

        public UtCategoriasController()
        {
            IRepositorioCategoria repositorioCategoria = new RepositorioCategoria();
            IServicoCategoria servicoCategoria = new ServicoCategoria(repositorioCategoria);
            _aplicacao = new AplicacaoCategoria(servicoCategoria);
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _controller = new CategoriasController(_aplicacao);

            AutoMapperConfig.RegisterMappings();
        }

        [Test]
        public void Index()
        {
            var view = _controller.Index();
            Assert.IsNotNull(view);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Details(int id)
        {
            var view = _controller.Details(id);
            Assert.IsNotNull(view);
        }

        [Test]
        public void Create()
        {
            var view = _controller.Create();
            Assert.IsNotNull(view);
        }

        [Test]
        [TestCase("Teste 1", true)]
        [TestCase("Teste 2", false)]
        public void Create(string nome, bool ativo)
        {
            var viewModelCreate = new ViewModelCreateCategoria() { Nome = nome, Ativo = ativo };
            var view = _controller.Create(viewModelCreate);
            Assert.IsNotNull(view);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Edit(int id)
        {
            var view = _controller.Edit(id);
            Assert.IsNotNull(view);
        }

        [Test]
        [TestCase(1, "Teste 1 - Edit", false)]
        [TestCase(2, "Teste 2 - Edit", true)]
        public void Edit(int id, string nome, bool ativo)
        {
            var viewModelCreate = new ViewModelEditCategoria() { Id = id, Nome = nome, Ativo = ativo };
            var view = _controller.Edit(viewModelCreate);
            Assert.IsNotNull(view);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Delete(int id)
        {
            var view = _controller.Delete(id);
            Assert.IsNotNull(view);
        }
    }
}