using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Mesa;
using Projeto.Restaurante.MVC.ViewModels.Pedido;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IAplicacaoPedido _aplicacaoPedido;
        private readonly IAplicacaoMesa _aplicacaoMesa;

        public PedidosController(IAplicacaoPedido aplicacaoPedido, IAplicacaoMesa aplicacaoMesa)
        {
            _aplicacaoPedido = aplicacaoPedido;
            _aplicacaoMesa = aplicacaoMesa;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsPedido> listViewModelDetails;
            using (_aplicacaoPedido)
                listViewModelDetails = Mapper.Map<IEnumerable<Pedido>, IEnumerable<ViewModelDetailsPedido>>(_aplicacaoPedido.GetAll());

            using (_aplicacaoMesa)
            {
                foreach (var viewModelDetailsPedido in listViewModelDetails)
                    viewModelDetailsPedido.Mesa = Mapper.Map<Mesa, ViewModelDetailsMesa>(_aplicacaoMesa.GetById(viewModelDetailsPedido.MesaId));
            }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewModelDetailsPedido viewModelDetails;
            using (_aplicacaoPedido)
                viewModelDetails = Mapper.Map<Pedido, ViewModelDetailsPedido>(_aplicacaoPedido.GetById(id));

            using (_aplicacaoMesa)
                viewModelDetails.Mesa = Mapper.Map<Mesa, ViewModelDetailsMesa>(_aplicacaoMesa.GetById(viewModelDetails.MesaId));

            return View(viewModelDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewModelCreatePedido viewModelCreate = new ViewModelCreatePedido();
            IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
            using (_aplicacaoMesa)
                listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

            viewModelCreate.Mesas = listViewModelDetails;
            return View(viewModelCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreatePedido viewModelCreate)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
                using (_aplicacaoMesa)
                    listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

                viewModelCreate.Mesas = listViewModelDetails;

                return View(viewModelCreate);
            }
            using (_aplicacaoPedido)
                _aplicacaoPedido.Add(Mapper.Map<ViewModelCreatePedido, Pedido>(viewModelCreate));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditPedido viewModelEdit;
            using (_aplicacaoPedido)
                viewModelEdit = Mapper.Map<Pedido, ViewModelEditPedido>(_aplicacaoPedido.GetById(id));

            IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
            using (_aplicacaoMesa)
                listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

            viewModelEdit.Mesas = listViewModelDetails;
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditPedido viewModelEdit)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
                using (_aplicacaoMesa)
                    listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

                viewModelEdit.Mesas = listViewModelDetails;

                return View(viewModelEdit);
            }
            using (_aplicacaoPedido)
                _aplicacaoPedido.Update(Mapper.Map<ViewModelEditPedido, Pedido>(viewModelEdit));

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (_aplicacaoPedido)
            {
                var obj = _aplicacaoPedido.GetById(id);
                _aplicacaoPedido.Remove(obj);
            }
            return RedirectToAction("Index");
        }

    }
}
