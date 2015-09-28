using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.MVC.Models;
using Projeto.Restaurante.MVC.Models.Enuns;
using Projeto.Restaurante.MVC.ViewModels.Opcao;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class OpcoesController : Controller
    {
        private readonly IAplicacaoOpcao _aplicacao;

        public OpcoesController(IAplicacaoOpcao aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsOpcao> listViewModelDetails = null;
            try
            {
                using (_aplicacao)
                    listViewModelDetails = Mapper.Map<IEnumerable<Opcao>, IEnumerable<ViewModelDetailsOpcao>>(_aplicacao.GetAll());
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsOpcao viewModelDetails = null;
            try
            {
                using (_aplicacao)
                    viewModelDetails = Mapper.Map<Opcao, ViewModelDetailsOpcao>(_aplicacao.GetById(id));
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
        public ActionResult Create(ViewModelCreateOpcao viewModelCreate)
        {
            if (!ModelState.IsValid)
                return View(viewModelCreate);
            try
            {
                using (_aplicacao)
                    _aplicacao.Add(Mapper.Map<ViewModelCreateOpcao, Opcao>(viewModelCreate));
                return RedirectToAction("Index");
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelCreate);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditOpcao viewModelEdit = null;
            try
            {
                using (_aplicacao)
                    viewModelEdit = Mapper.Map<Opcao, ViewModelEditOpcao>(_aplicacao.GetById(id));
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditOpcao viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            try
            {
                using (_aplicacao)
                    _aplicacao.Update(Mapper.Map<ViewModelEditOpcao, Opcao>(viewModelEdit));
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