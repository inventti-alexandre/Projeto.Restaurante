using System.Web.Mvc;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}