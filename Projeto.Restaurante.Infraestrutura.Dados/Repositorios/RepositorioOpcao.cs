using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioOpcao : RepositorioBase<Opcao> , IRepositorioOpcao
    {
        #region Existe Nomenclatura
        public bool ExisteNomenclaturaInformada(string nome)
        {
            var resultado = Convert.ToBoolean(Db.Opcoes.Count(x => x.Nome == nome));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Opcoes.Count(x => x.Nome == nome && x.Id != id));
            return resultado;
        }

        public IEnumerable<Opcao> GetAll(bool ativo)
        {
            return Db.Opcoes.Where(x => x.Ativo == ativo).ToList();
        }
        #endregion
    }
}
