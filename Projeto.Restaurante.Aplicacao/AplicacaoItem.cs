using System.Collections.Generic;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Aplicacao
{
    public class AplicacaoItem : AplicacaoBase<Item>, IAplicacaoItem
    {
        private readonly IServicoItem _servicoItem;

        public AplicacaoItem(IServicoItem servicoItem)
            : base(servicoItem)
        {
            _servicoItem = servicoItem;
        }

        public IEnumerable<Item> GetAll(bool ativo)
        {
            return _servicoItem.GetAll(ativo);
        }

        public IEnumerable<Item> GetAll(int pedidoId)
        {
            return _servicoItem.GetAll(pedidoId);
        }

        public IEnumerable<Item> GetAll(int pedidoId, bool ativo)
        {
            return _servicoItem.GetAll(pedidoId, ativo);
        }
    }
}
