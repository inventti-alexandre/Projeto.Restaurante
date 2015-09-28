using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Exceptions;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoPedido : ServicoBase<Pedido>, IServicoPedido
    {
        private readonly IRepositorioPedido _repositorioPedido;

        public ServicoPedido(IRepositorioPedido repositorioPedido)
            : base(repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public Pedido PedidoCorrente(int mesaId)
        {
            return _repositorioPedido.PedidoCorrente(mesaId);
        }

        /// <exception cref="MyException">Já consta um pedido para Mesa Informada!</exception>
        public override void Add(Pedido obj)
        {
            //if (_repositorioPedido.ExistePedido(obj.MesaId))
            //    throw new MyException("Já consta um pedido para Mesa Informada!");

            base.Add(obj);
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return base.GetAll().OrderByDescending(x => x.Id);
        }

        public IEnumerable<Pedido> GetAll(bool ativo)
        {
            return _repositorioPedido.GetAll(ativo).OrderByDescending(x => x.Id);
        }
    }
}
