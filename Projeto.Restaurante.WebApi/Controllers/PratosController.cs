using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.WebApi.ViewModels.Pratos;

namespace Projeto.Restaurante.WebApi.Controllers
{
    public class PratosController : ApiController
    {
        private readonly IAplicacaoPrato _aplicacao;

        public PratosController(IAplicacaoPrato aplicacao)
        {
            _aplicacao = aplicacao;
        }

        //#region Listagem
        //[HttpGet]
        //[Route("Api/Pratos/Categoria/{categoriaId:int}")]
        //public HttpResponseMessage ListarPorCategoria(int categoriaId)
        //{
        //    IEnumerable<ViewModelGetPrato> listViewModelGetPrato;
        //    try
        //    {
        //        IEnumerable<Prato> pratos = _aplicacao.Listar(new Categoria(categoriaId));
        //        listViewModelGetPrato = Mapper.Map<IEnumerable<Prato>, IEnumerable<ViewModelGetPrato>>(pratos);
        //    }
        //    catch (MyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, listViewModelGetPrato);
        //}
        //#endregion
    }
}
