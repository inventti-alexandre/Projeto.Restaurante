using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoPrato : IServicoBase<Prato>
    {
        IEnumerable<Prato> Listar(Categoria categoria);
    }
}
