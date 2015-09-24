using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Aplicacao.Interfaces
{
    public interface IAplicacaoPrato : IAplicacaoBase<Prato>
    {
        IEnumerable<Prato> Listar(Categoria categoria);
    }
}
