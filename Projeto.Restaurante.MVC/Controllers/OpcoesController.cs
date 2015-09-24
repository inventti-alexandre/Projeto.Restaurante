using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
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
            IEnumerable<ViewModelDetailsOpcao> listViewModelDetails;
            using (_aplicacao)
            {
                listViewModelDetails = Mapper.Map<IEnumerable<Opcao>, IEnumerable<ViewModelDetailsOpcao>>(_aplicacao.GetAll());
            }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsOpcao viewModelDetails;
            using (_aplicacao)
            {
                viewModelDetails = Mapper.Map<Opcao, ViewModelDetailsOpcao>(_aplicacao.GetById(id));
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
        public ActionResult Create(ViewModelCreateOpcao viewModelCreate)
        {
            if (!ModelState.IsValid)
                return View(viewModelCreate);
            using (_aplicacao)
            {
                _aplicacao.Add(Mapper.Map<ViewModelCreateOpcao, Opcao>(viewModelCreate));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditOpcao viewModelEdit;
            using (_aplicacao)
            {
                viewModelEdit = Mapper.Map<Opcao, ViewModelEditOpcao>(_aplicacao.GetById(id));
            }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditOpcao viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            using (_aplicacao)
            {
                _aplicacao.Update(Mapper.Map<ViewModelEditOpcao, Opcao>(viewModelEdit));
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