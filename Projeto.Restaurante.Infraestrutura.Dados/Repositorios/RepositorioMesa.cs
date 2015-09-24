using System;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioMesa : RepositorioBase<Mesa>, IRepositorioMesa
    {
        #region Existe Nomenclatura
        public bool ExisteNomenclaturaInformada(string nome)
        {
            var resultado = Convert.ToBoolean(Db.Mesas.Count(x => x.Nome == nome));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Mesas.Count(x => x.Nome == nome && x.Id != id));
            return resultado;
        }
        #endregion
    }
}
