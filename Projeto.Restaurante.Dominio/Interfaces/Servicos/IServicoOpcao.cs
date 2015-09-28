using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Servicos
{
    public interface IServicoOpcao : IServicoBase<Opcao>
    {
        IEnumerable<Opcao> GetAll(bool ativo);
    }
}
