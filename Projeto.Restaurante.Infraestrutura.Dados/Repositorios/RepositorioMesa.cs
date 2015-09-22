using System.Collections.Generic;
using System.Linq;
using Projeto.Restaurante.Dominio.Entidades;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;

namespace Projeto.Restaurante.Infraestrutura.Dados.Repositorios
{
    public class RepositorioMesa : RepositorioBase<Mesa>, IRepositorioMesa
    {
        #region Listar
        public IEnumerable<Mesa> Listar()
        {
            return Db.Mesas.ToList();
        }
        #endregion
    }
}
