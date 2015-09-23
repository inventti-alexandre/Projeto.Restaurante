using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class MesasController : Controller
    {
        private readonly IAplicacaoMesa _aplicacaoMesa;

        public MesasController(IAplicacaoMesa aplicacaoMesa)
        {
            _aplicacaoMesa = aplicacaoMesa;
        }

        // GET: Mesas
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsMesa> viewModelModelDetailsMesas;
            using (_aplicacaoMesa)
            {
                viewModelModelDetailsMesas = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll());
            }
            return View(viewModelModelDetailsMesas);
        }

        // GET: Mesas/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsMesa viewModelDetailsMesa;
            using (_aplicacaoMesa)
            {
                viewModelDetailsMesa = Mapper.Map<Mesa, ViewModelDetailsMesa>(_aplicacaoMesa.GetById(id));
            }
            return View(viewModelDetailsMesa);
        }

        // GET: Mesas/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mesas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreateMesa viewModelMesaCreateMesa)
        {
            if (!ModelState.IsValid)
                return View(viewModelMesaCreateMesa);
            using (_aplicacaoMesa)
            {
                _aplicacaoMesa.Add(Mapper.Map<ViewModelCreateMesa, Mesa>(viewModelMesaCreateMesa));
            }
            return RedirectToAction("Index");
        }

        // GET: Mesas/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditMesa viewModelMesEditMesa;
            using (_aplicacaoMesa)
            {
                viewModelMesEditMesa = Mapper.Map<Mesa, ViewModelEditMesa>(_aplicacaoMesa.GetById(id));
            }
            return View(viewModelMesEditMesa);
        }

        // POST: Mesas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditMesa viewModelEditMesa)
        {
            if (!ModelState.IsValid)
                return View(viewModelEditMesa);
            using (_aplicacaoMesa)
            {
                _aplicacaoMesa.Update(Mapper.Map<ViewModelEditMesa, Mesa>(viewModelEditMesa));
            }
            return RedirectToAction("Index");
        }

        // GET: Mesas/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_aplicacaoMesa)
            {
                var mesa = _aplicacaoMesa.GetById(id);
                _aplicacaoMesa.Remove(mesa);
            }
            return RedirectToAction("Index");
        }

    }
}
