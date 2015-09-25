using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoCategoria : IAplicacaoBase<Categoria>
    {
        IEnumerable<Categoria> GetAll(bool ativo);
    }
}
