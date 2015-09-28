using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.MVC.Models;
using Projeto.Restaurante.MVC.Models.Enuns;
using Projeto.Restaurante.MVC.ViewModels.Categoria;
using Projeto.Restaurante.MVC.ViewModels.Prato;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class PratosController : Controller
    {
        private readonly IAplicacaoPrato _aplicacaoPrato;
        private readonly IAplicacaoCategoria _aplicacaoCategoria;

        public PratosController(IAplicacaoPrato aplicacaoPrato, IAplicacaoCategoria aplicacaoCategoria)
        {
            _aplicacaoPrato = aplicacaoPrato;
            _aplicacaoCategoria = aplicacaoCategoria;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsPrato> listViewModelDetails = null;
            try
            {
                using (_aplicacaoPrato)
                    listViewModelDetails = Mapper.Map<IEnumerable<Prato>, IEnumerable<ViewModelDetailsPrato>>(_aplicacaoPrato.GetAll());
                using (_aplicacaoCategoria)
                {
                    foreach (var viewModelDetailsPrato in listViewModelDetails)
                    {
                        viewModelDetailsPrato.Categoria = Mapper.Map<Categoria, ViewModelDetailsCategoria>(_aplicacaoCategoria.GetById(viewModelDetailsPrato.CategoriaId));
                    }
                }
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsPrato viewModelDetails = null;
            try
            {
                using (_aplicacaoPrato)
                    viewModelDetails = Mapper.Map<Prato, ViewModelDetailsPrato>(_aplicacaoPrato.GetById(id));
                using (_aplicacaoCategoria)
                    viewModelDetails.Categoria = Mapper.Map<Categoria, ViewModelDetailsCategoria>(_aplicacaoCategoria.GetById(viewModelDetails.CategoriaId));
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModelCreate = new ViewModelCreatePrato();
            try
            {
                IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
                using (_aplicacaoCategoria)
                    listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll(true));
                viewModelCreate.Categorias = listViewModelDetails;
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreatePrato viewModelCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
                    using (_aplicacaoCategoria)
                        listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll(true));
                    viewModelCreate.Categorias = listViewModelDetails;
                    return View(viewModelCreate);
                }
                using (_aplicacaoPrato)
                    _aplicacaoPrato.Add(Mapper.Map<ViewModelCreatePrato, Prato>(viewModelCreate));
                return RedirectToAction("Index");

            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditPrato viewModelEdit = null;
            try
            {
                using (_aplicacaoPrato)
                    viewModelEdit = Mapper.Map<Prato, ViewModelEditPrato>(_aplicacaoPrato.GetById(id));
                IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
                using (_aplicacaoCategoria)
                    listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll(true));
                viewModelEdit.Categorias = listViewModelDetails;
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditPrato viewModelEdit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
                    using (_aplicacaoCategoria)
                        listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll(true));
                    viewModelEdit.Categorias = listViewModelDetails;
                    return View(viewModelEdit);
                }
                using (_aplicacaoPrato)
                    _aplicacaoPrato.Update(Mapper.Map<ViewModelEditPrato, Prato>(viewModelEdit));
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
                using (_aplicacaoPrato)
                {
                    var obj = _aplicacaoPrato.GetById(id);
                    _aplicacaoPrato.Remove(obj);
                }
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return RedirectToAction("Index");
        }
    }
}