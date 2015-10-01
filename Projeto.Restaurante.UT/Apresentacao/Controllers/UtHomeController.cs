using NUnit.Framework;
using Projeto.Restaurante.MVC.Controllers;

namespace Projeto.Restaurante.UT.Apresentacao.Controllers
{
    [TestFixture]
    public class UtHomeController
    {
        [Test]
        public void Index()
        {
            var controller = new HomeController();
            var view = controller.Index();
            Assert.IsNotNull(view);
        }
    }
}
