using System;
using System.Collections.Generic;
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
            var resultado = Convert.ToBoolean(Db.Categorias.Count(x => x.Nome == nome));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Categorias.Count(x => x.Nome == nome && x.Id != id));
            return resultado;
        }
        #endregion
        
        public IEnumerable<Categoria> GetAll(bool ativo)
        {
            return base.GetAll().Where(x => x.Ativo == ativo).OrderBy(x => x.Nome);
        }
    }
}
