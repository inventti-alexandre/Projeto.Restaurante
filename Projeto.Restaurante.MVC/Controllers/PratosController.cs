using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
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
            IEnumerable<ViewModelDetailsPrato> listViewModelDetails;
            using (_aplicacaoPrato)
            {
                listViewModelDetails = Mapper.Map<IEnumerable<Prato>, IEnumerable<ViewModelDetailsPrato>>(_aplicacaoPrato.GetAll());
            }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsPrato viewModelDetails;
            using (_aplicacaoPrato)
            {
                viewModelDetails = Mapper.Map<Prato, ViewModelDetailsPrato>(_aplicacaoPrato.GetById(id));
            }
            return View(viewModelDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewModelCreatePrato viewModelCreate = new ViewModelCreatePrato();
            IEnumerable<ViewModelDetailsCategoria> listViewModelDetails;
            using (_aplicacaoCategoria)
            {
                listViewModelDetails = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll());
            }
            viewModelCreate.CategoriaId = listViewModelDetails;
            return View(viewModelCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreatePrato viewModelCreate)
        {
            if (!ModelState.IsValid)
                return View(viewModelCreate);
            using (_aplicacaoPrato)
            {
                _aplicacaoPrato.Add(Mapper.Map<ViewModelCreatePrato, Prato>(viewModelCreate));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditPrato viewModelEdit;
            using (_aplicacaoPrato)
            {
                viewModelEdit = Mapper.Map<Prato, ViewModelEditPrato>(_aplicacaoPrato.GetById(id));
            }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditPrato viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            using (_aplicacaoPrato)
            {
                _aplicacaoPrato.Update(Mapper.Map<ViewModelEditPrato, Prato>(viewModelEdit));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_aplicacaoPrato)
            {
                var obj = _aplicacaoPrato.GetById(id);
                _aplicacaoPrato.Remove(obj);
            }
            return RedirectToAction("Index");
        }
    }
}