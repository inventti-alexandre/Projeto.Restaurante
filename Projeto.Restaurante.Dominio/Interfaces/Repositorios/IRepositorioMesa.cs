using System.Collections.Generic;
using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMesa : IRepositorioBase<Mesa>
    {
        bool ExisteNomenclaturaInformada(string nome);
        bool ExisteNomenclaturaInformada(int id, string nome);
        IEnumerable<Mesa> GetAll(bool ativo);
    }
}
