using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.MVC.Models;
using Projeto.Restaurante.MVC.Models.Enuns;
using Projeto.Restaurante.MVC.ViewModels.Categoria;
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
        private readonly IAplicacaoCategoria _aplicacaoCategoria;
        private readonly IAplicacaoPrato _aplicacaoPrato;
        private readonly IAplicacaoOpcao _aplicacaoOpcao;

        public PedidosController(IAplicacaoPedido aplicacaoPedido, IAplicacaoMesa aplicacaoMesa, IAplicacaoCategoria aplicacaoCategoria, IAplicacaoPrato aplicacaoPrato, IAplicacaoOpcao aplicacaoOpcao)
        {
            _aplicacaoPedido = aplicacaoPedido;
            _aplicacaoMesa = aplicacaoMesa;
            _aplicacaoCategoria = aplicacaoCategoria;
            _aplicacaoPrato = aplicacaoPrato;
            _aplicacaoOpcao = aplicacaoOpcao;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ViewModelDetailsPedido> listViewModelDetails = null;
            try
            {
                using (_aplicacaoPedido)
                    listViewModelDetails = Mapper.Map<IEnumerable<Pedido>, IEnumerable<ViewModelDetailsPedido>>(_aplicacaoPedido.GetAll());
                using (_aplicacaoMesa)
                {
                    foreach (var viewModelDetailsPedido in listViewModelDetails)
                        viewModelDetailsPedido.Mesa = Mapper.Map<Mesa, ViewModelDetailsMesa>(_aplicacaoMesa.GetById(viewModelDetailsPedido.MesaId));
                }
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(listViewModelDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModelCreate = new ViewModelCreatePedido();
            try
            {
                IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
                using (_aplicacaoMesa)
                    listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));
                viewModelCreate.Mesas = listViewModelDetails;
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelCreatePedido viewModelCreate)
        {
            Pedido pedido = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ViewModelDetailsMesa> listViewModelDetails;
                    using (_aplicacaoMesa)
                        listViewModelDetails = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));
                    viewModelCreate.Mesas = listViewModelDetails;
                    return View(viewModelCreate);
                }
                pedido = Mapper.Map<ViewModelCreatePedido, Pedido>(viewModelCreate);
                using (_aplicacaoPedido)
                    _aplicacaoPedido.Add(pedido);
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return Redirect(string.Format("/Pedidos/Edit/{0}", pedido != null ? pedido.Id : 0));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewModelEditPedido viewModelEdit = null;
            try
            {
                using (_aplicacaoPedido)
                    viewModelEdit = Mapper.Map<Pedido, ViewModelEditPedido>(_aplicacaoPedido.GetById(id));
                IEnumerable<ViewModelDetailsMesa> listViewModelDetailsMesas;
                using (_aplicacaoMesa)
                    listViewModelDetailsMesas = Mapper.Map<IEnumerable<Mesa>, IEnumerable<ViewModelDetailsMesa>>(_aplicacaoMesa.GetAll(true));
                IEnumerable<ViewModelDetailsCategoria> listViewModelDetailsCategorias;
                using (_aplicacaoCategoria)
                {
                    listViewModelDetailsCategorias = Mapper.Map<IEnumerable<Categoria>, IEnumerable<ViewModelDetailsCategoria>>(_aplicacaoCategoria.GetAll(true)).ToList();
                    using (_aplicacaoPrato)
                    {
                        foreach (var categoria in listViewModelDetailsCategorias)
                        {
                            categoria.Pratos = Mapper.Map<IEnumerable<Prato>, IEnumerable<ViewModelDetailsPrato>>(_aplicacaoPrato.GetAll(categoria.Id, true, true));
                        }
                    }
                }
                IEnumerable<ViewModelDetailsOpcao> listViewModelDetailsOpcaos;
                using (_aplicacaoOpcao)
                    listViewModelDetailsOpcaos = Mapper.Map<IEnumerable<Opcao>, IEnumerable<ViewModelDetailsOpcao>>(_aplicacaoOpcao.GetAll(true));
                viewModelEdit.Mesas = listViewModelDetailsMesas;
                viewModelEdit.Categorias = listViewModelDetailsCategorias;
                viewModelEdit.Opcoes = listViewModelDetailsOpcaos;
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModelEditPedido viewModelEdit)
        {
            try
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
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return View(viewModelEdit);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                using (_aplicacaoPedido)
                {
                    var obj = _aplicacaoPedido.GetById(id);
                    _aplicacaoPedido.Remove(obj);
                }
            }
            catch (MyException ex) { ViewBag.Alerta = new Alerta(ex.Message, TipoDeAlerta.Aviso); }
            return RedirectToAction("Index");
        }

    }
}
