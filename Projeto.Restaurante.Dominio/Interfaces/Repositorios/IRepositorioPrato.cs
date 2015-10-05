using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioPrato : IRepositorioBase<Prato>
    {

        bool ExisteNomenclaturaInformada(string nome);
        bool ExisteNomenclaturaInformada(int id, string nome);
        IEnumerable<Prato> GetAll(bool ativo);
        IEnumerable<Prato> GetAll(int categoriaId);
        IEnumerable<Prato> GetAll(int categoriaId, bool ativo);
        IEnumerable<Prato> GetAll(int categoriaId, bool disponivel, bool ativo);
    }
}
