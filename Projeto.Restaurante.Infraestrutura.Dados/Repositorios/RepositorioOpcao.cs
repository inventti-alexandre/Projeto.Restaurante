using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioOpcao : RepositorioBase<Opcao> , IRepositorioOpcao
    {
        #region Listar
        public IEnumerable<Opcao> Listar()
        {
            return Db.Opcoes.ToList();
        }
        #endregion

        #region Existe Nomenclatura
        public bool ExisteNomenclaturaInformada(string nome)
        {
            var resultado = Convert.ToBoolean(Db.Opcoes.Where(x => x.Nome == nome).Select(x => x.Id));
            return resultado;
        }

        public bool ExisteNomenclaturaInformada(int id, string nome)
        {
            var resultado = Convert.ToBoolean(Db.Opcoes.Where(x => x.Nome == nome && x.Id != id).Select(x => x.Id));
            return resultado;
        }
        #endregion
    }
}
