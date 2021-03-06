﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Projeto.Restaurante.Aplicacao;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;
using Projeto.Restaurante.Dominio.Servicos;
using Projeto.Restaurante.Infraestrutura.Dados.Repositorios;
using Projeto.Restaurante.WebApi.ViewModels.Item;

namespace Projeto.Restaurante.WebApi.Controllers.V1
{
    [RoutePrefix("Api/V1")]
    public class ServicoItensController : ApiController
    {
        private readonly IAplicacaoItem _aplicacaoItem;

        //public ServicoItensController(IAplicacaoItem aplicacaoItem)
        //{
        //    _aplicacaoItem = aplicacaoItem;
        //}

        public ServicoItensController()
        {
            IRepositorioItem repositorioItem = new RepositorioItem();
            IServicoItem servicoItem = new ServicoItem(repositorioItem);
            _aplicacaoItem = new AplicacaoItem(servicoItem);
        }

        [HttpGet]
        [Route("ServicoItens/{pedidoId:int}")]
        public HttpResponseMessage Get(int pedidoId)
        {
            IEnumerable<ViewModelGetItem> viewModelGetItens;
            try
            {
                using (_aplicacaoItem)
                    viewModelGetItens = Mapper.Map<IEnumerable<Item>, IEnumerable<ViewModelGetItem>>(_aplicacaoItem.GetAll(pedidoId, true));
            }
            catch (MyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, viewModelGetItens);
        }

        [HttpPost]
        [Route("ServicoItens")]
        public HttpResponseMessage Post(ViewModelPostItem viewModelPostItem)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Item item;
            try
            {
                item = Mapper.Map<ViewModelPostItem, Item>(viewModelPostItem);
                using (_aplicacaoItem)
                    _aplicacaoItem.Add(item);
            }
            catch (MyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }

            var viewModelGetItem = Mapper.Map<Item, ViewModelGetItem>(item);
            return Request.CreateResponse(HttpStatusCode.Created, viewModelGetItem);
        }

        [HttpPut]
        [Route("ServicoItens")]
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("ServicoItens")]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}