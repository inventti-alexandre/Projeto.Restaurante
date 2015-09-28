using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.ViewModels.Pedido
{
    public class ViewModelDetailsPedido
    {
        #region Propriedades
        [Key]
        [DisplayName("Pedido")]
        public int Id { get; set; }

        [DisplayName("Mesa")]
        public int MesaId { get; set; }

        [DisplayName("Mesa")]
        public ViewModelDetailsMesa Mesa { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}