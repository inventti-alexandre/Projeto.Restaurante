using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioCategoria : IRepositorioBase<Categoria>
    {
        bool ExisteNomenclaturaInformada(string nome);
        bool ExisteNomenclaturaInformada(int id, string nome);
    }
}
