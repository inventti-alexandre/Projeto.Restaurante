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
    }
}
