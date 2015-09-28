using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.MVC.Models;
using Projeto.Restaurante.MVC.Models.Enuns;
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
            IEnumerable<ViewModelDetailsCategoria> listViewModelDetails = null;
            try
            {
                using (_aplicacao)
                    listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacao.GetAll());
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsCategoria viewModelDetails = null;
            try
            {
                using (_aplicacao)
                    viewModelDetails = Mapper.Map<Categoria, ViewModelDetailsCategoria>(_aplicacao.GetById(id));
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
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
            try
            {
                using (_aplicacao)
                    _aplicacao.Add(Mapper.Map<ViewModelCreateCategoria, Categoria>(viewModelCreate));
                return RedirectToAction("Index");
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditCategoria viewModelEdit = null;
            try
            {
                using (_aplicacao)
                    viewModelEdit = Mapper.Map<Categoria, ViewModelEditCategoria>(_aplicacao.GetById(id));
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditCategoria viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            try
            {
                using (_aplicacao)
                    _aplicacao.Update(Mapper.Map<ViewModelEditCategoria, Categoria>(viewModelEdit));
                return RedirectToAction("Index");
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                using (_aplicacao)
                {
                    var obj = _aplicacao.GetById(id);
                    _aplicacao.Remove(obj);
                }
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return RedirectToAction("Index");
        }
    }
}
