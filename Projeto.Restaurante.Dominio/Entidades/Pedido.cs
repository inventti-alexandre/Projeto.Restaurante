using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Pedido : Base
    {
        #region Propriedades
        public int MesaId { get; private set; }
        public virtual Mesa Mesa { get; private set; }
        public virtual IList<Item> Itens { get; private set; }
        #endregion

        #region Construtores
        public Pedido()
        {
            
        }
        #endregion

        #region Preencher

        public void PreencherItens()
        {
            Itens = Item.Listar(this);
        }
        public async Task PreencherItensAsync()
        {
            await Task.Run(() => PreencherItens());
        }
        #endregion

        #region Listar
        public static IEnumerable<Pedido> Listar()
        {
            return new List<Pedido>();
        }
        public static async Task<IEnumerable<Pedido>> ListarComItensPreenchidosAsync()
        {
            var pedidos = Listar();
            var tasks = pedidos.Select(async pedido => await pedido.PreencherItensAsync());
            await Task.WhenAll(tasks);
            return pedidos;
        }
        #endregion
        //Verificar se já consta pedido para mesa
        //Pedidos já foram entregues
        //valor da conta
    }
}
