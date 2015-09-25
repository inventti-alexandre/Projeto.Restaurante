using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoCategoria : IServicoBase<Categoria>
    {
        IEnumerable<Categoria> GetAll(bool ativo);
    }
}
