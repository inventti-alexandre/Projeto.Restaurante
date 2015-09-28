using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoItem : IAplicacaoBase<Item>
    {
        IEnumerable<Item> GetAll(bool ativo);
        IEnumerable<Item> GetAll(int pedidoId);
        IEnumerable<Item> GetAll(int pedidoId, bool ativo);
    }
}
