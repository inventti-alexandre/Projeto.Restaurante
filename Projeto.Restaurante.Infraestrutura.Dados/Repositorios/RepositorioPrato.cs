using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPrato : RepositorioBase<Prato>, IRepositorioPrato
    {
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

        #region GetAll
        public IEnumerable<Prato> GetAll(bool ativo)
        {
            return Db.Pratos.Where(x => x.Ativo == ativo).ToList();
        }

        public IEnumerable<Prato> GetAll(int categoriaId)
        {
            return Db.Pratos.Where(x => x.CategoriaId == categoriaId).ToList();
        }

        public IEnumerable<Prato> GetAll(int categoriaId, bool ativo)
        {
            return Db.Pratos.Where(x => x.CategoriaId == categoriaId && x.Ativo == ativo).ToList();
        }
        #endregion
    }
}
