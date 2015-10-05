using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoPrato : IServicoBase<Prato>
    {
        IEnumerable<Prato> GetAll(bool ativo);
        IEnumerable<Prato> GetAll(int categoriaId);
        IEnumerable<Prato> GetAll(int categoriaId, bool ativo);
        IEnumerable<Prato> GetAll(int categoriaId, bool disponivel, bool ativo);
    }
}
