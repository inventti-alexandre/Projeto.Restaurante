using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria> , IRepositorioCategoria
    {
        #region Listar
        public IEnumerable<Categoria> Listar()
        {
            return Db.Categorias.ToList();
        }
        #endregion
    }
}
