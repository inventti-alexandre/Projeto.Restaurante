using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels;

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
            IEnumerable<ViewModelMesa> viewModelMesas;
            using (_aplicacaoMesa)
            {
                viewModelMesas = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelMesa>>(_aplicacaoMesa.GetAll());
            }
            return View(viewModelMesas);
        }

        // GET: Mesas/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelMesa viewModelMesa;
            using (_aplicacaoMesa)
            {
                viewModelMesa = Mapper.Map<Mesa, ViewModelMesa>(_aplicacaoMesa.GetById(id));
            }
            return View(viewModelMesa);
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
        public ActionResult Create(ViewModelMesa viewModelMesa)
        {
            if (!ModelState.IsValid)
                return View(viewModelMesa);
            using (_aplicacaoMesa)
            {
                _aplicacaoMesa.Add(Mapper.Map<ViewModelMesa, Mesa>(viewModelMesa));
            }
            return RedirectToAction("Index");
        }

        // GET: Mesas/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelMesa viewModelMesa;
            using (_aplicacaoMesa)
            {
                viewModelMesa = Mapper.Map<Mesa, ViewModelMesa>(_aplicacaoMesa.GetById(id));
            }
            return View(viewModelMesa);
        }

        // POST: Mesas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelMesa viewModelMesa)
        {
            if (!ModelState.IsValid)
                return View(viewModelMesa);
            using (_aplicacaoMesa)
            {
                _aplicacaoMesa.Update(Mapper.Map<ViewModelMesa, Mesa>(viewModelMesa));
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
