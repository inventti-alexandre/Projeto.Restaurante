using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoMesa : IServicoBase<Mesa>
    {
        IEnumerable<Mesa> GetAll(bool ativo);
    }
}
