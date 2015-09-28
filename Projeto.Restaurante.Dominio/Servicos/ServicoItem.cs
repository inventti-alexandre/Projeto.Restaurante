using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;

namespace Projeto.Restaurante.Dominio.Servicos
{
    public class ServicoItem : ServicoBase<Item>, IServicoItem
    {
        private readonly IRepositorioItem _repositorioItem;

        public ServicoItem(IRepositorioItem repositorioItem)
            : base(repositorioItem)
        {
            _repositorioItem = repositorioItem;
        }
        
        public override IEnumerable<Item> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Prato.Nome);
        }
        public IEnumerable<Item> GetAll(bool ativo)
        {
            return _repositorioItem.GetAll(ativo).OrderBy(x => x.Prato.Nome);
        }

        public IEnumerable<Item> GetAll(int pedidoId)
        {
            return _repositorioItem.GetAll(pedidoId).OrderBy(x => x.Prato.Nome);
        }
        public IEnumerable<Item> GetAll(int pedidoId, bool ativo)
        {
            return _repositorioItem.GetAll(pedidoId, ativo).OrderBy(x => x.Prato.Nome);
        }

    }
}
