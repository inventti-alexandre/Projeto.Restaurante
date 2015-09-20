using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Restaurante.Dominio.Entidades
{
    public class Pedido : Base
    {
        #region Propriedades
        public Mesa Mesa { get; private set; }
        public virtual List<Item> Itens { get; private set; }
        #endregion

        #region Construtores

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
        public static List<Pedido> Listar()
        {
            return new List<Pedido>();
        }
        public static async Task<List<Pedido>> ListarComItensPreenchidosAsync()
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
