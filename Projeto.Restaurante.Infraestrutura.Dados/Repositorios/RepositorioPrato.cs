using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPrato : RepositorioBase<Prato>, IRepositorioPrato
    {
        #region Listar
        public IEnumerable<Prato> Listar(Categoria categoria)
        {
            return Db.Pratos.Where(x => x.CategoriaId == categoria.Id).ToList();
        }
        #endregion

        #region Existe Nomenclatura
        public bool ExisteNomenclaturaInformada(string nome)
        {
            var resultado = Convert.ToBoolean(Db.Pratos.Count(x => x.Nome == nome));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Pratos.Count(x => x.Nome == nome && x.Id != id));
            return resultado;
        }
        #endregion
    }
}
