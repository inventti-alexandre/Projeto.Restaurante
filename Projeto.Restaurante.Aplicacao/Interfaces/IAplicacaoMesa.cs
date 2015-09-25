using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoMesa : IAplicacaoBase<Mesa>
    {
        IEnumerable<Mesa> GetAll(bool ativo);
    }
}
