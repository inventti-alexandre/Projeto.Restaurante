﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class MesasController : Controller
    {
        private readonly IAplicacaoMesa _aplicacao;

        public MesasController(IAplicacaoMesa aplicacao)
        {
            _aplicacao = aplicacao;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
            using (_aplicacao)
            {
                listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacao.GetAll());
            }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsMesa viewModelDetails;
            using (_aplicacao)
            {
                viewModelDetails = Mapper.Map<Mesa, ViewModelDetailsMesa>(_aplicacao.GetById(id));
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
        public ActionResult Create(ViewModelCreateMesa viewModelCreate)
        {
            if (!ModelState.IsValid)
                return View(viewModelCreate);
            using (_aplicacao)
            {
                _aplicacao.Add(Mapper.Map<ViewModelCreateMesa, Mesa>(viewModelCreate));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditMesa viewModelEdit;
            using (_aplicacao)
            {
                viewModelEdit = Mapper.Map<Mesa, ViewModelEditMesa>(_aplicacao.GetById(id));
            }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditMesa viewModelEdit)
        {
            if (!ModelState.IsValid)
                return View(viewModelEdit);
            using (_aplicacao)
            {
                _aplicacao.Update(Mapper.Map<ViewModelEditMesa, Mesa>(viewModelEdit));
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
