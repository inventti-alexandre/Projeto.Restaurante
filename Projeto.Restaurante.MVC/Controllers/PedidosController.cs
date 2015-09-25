using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.MVC.ViewModels.Mesa;
using Projeto.Restaurante.MVC.ViewModels.Opcao;
using Projeto.Restaurante.MVC.ViewModels.Pedido;
using Projeto.Restaurante.MVC.ViewModels.Prato;

namespace Projeto.Restaurante.MVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IAplicacaoPedido _aplicacaoPedido;
        private readonly IAplicacaoMesa _aplicacaoMesa;
        private readonly IAplicacaoPrato _aplicacaoPrato;
        private readonly IAplicacaoOpcao _aplicacaoOpcao;

        public PedidosController(IAplicacaoPedido aplicacaoPedido, IAplicacaoMesa aplicacaoMesa, IAplicacaoPrato aplicacaoPrato, IAplicacaoOpcao aplicacaoOpcao)
        {
            _aplicacaoPedido = aplicacaoPedido;
            _aplicacaoMesa = aplicacaoMesa;
            _aplicacaoPrato = aplicacaoPrato;
            _aplicacaoOpcao = aplicacaoOpcao;
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
            var pedido = Mapper.Map<ViewModelCreatePedido, Pedido>(viewModelCreate);
            using (_aplicacaoPedido)
                _aplicacaoPedido.Add(pedido);

            return Redirect(string.Format("/Pedidos/Edit/{0}", pedido.Id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditPedido viewModelEdit;
            using (_aplicacaoPedido)
                viewModelEdit = Mapper.Map<Pedido, ViewModelEditPedido>(_aplicacaoPedido.GetById(id));

            IEnumerable<ViewModelDetailsMesa> listViewModelDetailsMesas;
            using (_aplicacaoMesa)
                listViewModelDetailsMesas = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

            IEnumerable<ViewModelDetailsPrato> listViewModelDetailsPratos;
            using (_aplicacaoPrato)
                listViewModelDetailsPratos = Mapper.Map<IEnumerable<Prato>, IEnumerable<ViewModelDetailsPrato>>(_aplicacaoPrato.GetAll());

            IEnumerable<ViewModelDetailsOpcao> listViewModelDetailsOpcaos;
            using (_aplicacaoOpcao)
                listViewModelDetailsOpcaos = Mapper.Map<IEnumerable<Opcao>, IEnumerable<ViewModelDetailsOpcao>>(_aplicacaoOpcao.GetAll());

            viewModelEdit.Mesas = listViewModelDetailsMesas;
            viewModelEdit.Pratos = listViewModelDetailsPratos;
            viewModelEdit.Opcoes = listViewModelDetailsOpcaos;

            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditPedido viewModelEdit)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ViewModelDetailsMesa> listViewModelDetailsMesas;
                using (_aplicacaoMesa)
                    listViewModelDetailsMesas = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));

                viewModelEdit.Mesas = listViewModelDetailsMesas;

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
