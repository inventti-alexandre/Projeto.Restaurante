using Projeto.Restaurante.Dominio.Entidades;

namespace Projeto.Restaurante.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioOpcao : IRepositorioBase<Opcao>
    {
        bool ExisteNomenclaturaInformada(string nome);
        bool ExisteNomenclaturaInformada(int id, string nome);
    }
}
