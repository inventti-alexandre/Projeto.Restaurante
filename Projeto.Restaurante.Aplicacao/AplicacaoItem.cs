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

        public IEnumerable<Item> Listar(Pedido pedido)
        {
            return _servicoItem.Listar(pedido);
        }
    }
}
