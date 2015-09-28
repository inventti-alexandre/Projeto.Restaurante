using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Servicos.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.Servicos.WebApi.Controllers.V1
{
    [RoutePrefix("Api/V1")]
    public class ItensController : ApiController
    {
        //private readonly IAplicacaoItem _aplicacaoItem;

        //public ItensController(IAplicacaoItem aplicacaoItem)
        //{
        //    _aplicacaoItem = aplicacaoItem;
        //}

        [HttpGet]
        [Route("Itens/{pedidoid:int}")]
        public HttpResponseMessage Get(int pedidoId)
        {
            IEnumerable<ViewModelGetItem> viewModelGetItens;
            try
            {
                var pedido = new Pedido();
                var itens = new List<Item>();
                viewModelGetItens = Mapper.Map<IEnumerable<Item>, IEnumerable<ViewModelGetItem>>(itens);
            }
            catch (MyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, viewModelGetItens);
        }

        [HttpPost]
        [Route("Itens")]
        public HttpResponseMessage Post(ViewModelPostItem viewModelPostItem)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Item item;
            try
            {
                item = Mapper.Map<ViewModelPostItem, Item>(viewModelPostItem);
                //using (_aplicacaoItem)
                //    _aplicacaoItem.Add(item);
            }
            catch (MyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }

            var viewModelGetItem = Mapper.Map<Item, ViewModelGetItem>(item);
            return Request.CreateResponse(HttpStatusCode.Created, viewModelGetItem);
        }
    }
}
