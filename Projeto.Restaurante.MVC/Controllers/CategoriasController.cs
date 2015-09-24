using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Categoria;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly IAplicacaoCategoria _aplicacao;

        public CategoriasController(IAplicacaoCategoria aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
            using (_aplicacao)
            {
                listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacao.GetAll());
            }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsCategoria viewModelDetails;
            using (_aplicacao)
            {
                viewModelDetails = Mapper.Map<Categoria, ViewModelDetailsCategoria>(_aplicacao.GetById(id));
            }
            return View(viewModelDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreateCategoria viewModelCreate)
        {
            if (!ModelState.IsValid)
                return View(viewModelCreate);
            using (_aplicacao)
            {
                _aplicacao.Add(Mapper.Map<ViewModelCreateCategoria, Categoria>(viewModelCreate));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditCategoria viewModelEdit;
            using (_aplicacao)
            {
                viewModelEdit = Mapper.Map<Categoria, ViewModelEditCategoria>(_aplicacao.GetById(id));
            }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditCategoria viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            using (_aplicacao)
            {
                _aplicacao.Update(Mapper.Map<ViewModelEditCategoria, Categoria>(viewModelEdit));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_aplicacao)
            {
                var obj = _aplicacao.GetById(id);
                _aplicacao.Remove(obj);
            }
            return RedirectToAction("Index");
        }
    }
}
