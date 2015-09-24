using System;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria> , IRepositorioCategoria
    {
        #region Existe Nomenclatura
        public bool ExisteNomenclaturaInformada(string nome)
        {
            var resultado = Convert.ToBoolean(Db.Categorias.Where(x => x.Nome == nome).Select(x => x.Id));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Categorias.Where(x => x.Nome == nome && x.Id != id).Select(x => x.Id));
            return resultado;
        }
        #endregion
    }
}
