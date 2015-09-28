using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoOpcao : IAplicacaoBase<Opcao>
    {
        IEnumerable<Opcao> GetAll(bool ativo);
    }
}
