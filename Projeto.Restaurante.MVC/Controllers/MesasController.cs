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

        public MesasController()
        {
            
        }

        public MesasController(IAplicacaoMesa aplicacaoMesa)
        {
            _aplicacaoMesa = aplicacaoMesa;
        }

        // GET: Mesas
        [HttpGet]
        public ActionResult Index()
        {
            var viewModelMesa = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelMesa>>(_aplicacaoMesa.GetAll());

            return View(viewModelMesa);
        }

        // GET: Mesas/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var mesa = _aplicacaoMesa.GetById(id);
            var viewModelMesa = Mapper.Map<Mesa, ViewModelMesa>(mesa);

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
            if (ModelState.IsValid)
            {
                var mesa = Mapper.Map<ViewModelMesa, Mesa>(viewModelMesa);
                _aplicacaoMesa.Add(mesa);

                RedirectToAction("Index");
            }
                
            return View(viewModelMesa);
        }

        // GET: Mesas/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var mesa = _aplicacaoMesa.GetById(id);
            var viewModelMesa = Mapper.Map<Mesa, ViewModelMesa>(mesa);

            return View(viewModelMesa);
        }

        // POST: Mesas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelMesa viewModelMesa)
        {
            if (ModelState.IsValid)
            {
                var mesa = Mapper.Map<ViewModelMesa, Mesa>(viewModelMesa);
                _aplicacaoMesa.Update(mesa);

                RedirectToAction("Index");
            }

            return View(viewModelMesa);
        }

        // GET: Mesas/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var mesa = _aplicacaoMesa.GetById(id);
            var viewModelMesa = Mapper.Map<Mesa, ViewModelMesa>(mesa);

            return View(viewModelMesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var mesa = _aplicacaoMesa.GetById(id);
            _aplicacaoMesa.Remove(mesa);

            return RedirectToAction("Index");
        }
    }
}
