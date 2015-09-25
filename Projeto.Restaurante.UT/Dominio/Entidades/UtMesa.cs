using System.Linq;
using NUnit.Framework;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;

namespace Projeto.Restaurante.UT.Dominio.Entidades
{
    [TestFixture]
    public class UtMesa
    {
        private readonly IAplicacaoMesa _aplicacao;

        public UtMesa()
        {
            
        }

        public UtMesa(IAplicacaoMesa aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [TestFixtureSetUp]
        public void Setup()
        {

        }

        [Test]
        public void Cadastrar()
        {
            var obj = new Mesa("Teste1");

            Assert.DoesNotThrow(() => _aplicacao.Add(obj));
            Assert.AreNotEqual(0, obj.Id);
        }

        [Test]
        public void CadastrarMesmoNome()
        {
            var obj = new Mesa("Teste1");

            Assert.Throws<MyException>(() => _aplicacao.Add(obj));
        }

        [Test]
        public void Alterar()
        {
            const string nome = "Teste - X";
            var obj = new Mesa(1, nome);

            Assert.DoesNotThrow(() => _aplicacao.Update(obj));
        }

        [Test]
        public void Listar()
        {
            var list = _aplicacao.GetAll();

            Assert.IsNotNull(list);
            Assert.AreNotEqual(0, list.Count());
        }


        [Test]
        public void Consultar()
        {
            var obj = _aplicacao.GetById(1);

            Assert.IsNotNull(obj);
        }
    }
}
