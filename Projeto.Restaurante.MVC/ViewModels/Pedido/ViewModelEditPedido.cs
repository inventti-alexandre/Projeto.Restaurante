using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.MVC.ViewModels.Item;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.ViewModels.Pedido
{
    public class ViewModelEditPedido
    {
        #region Propriedades
        [Key]
        [DisplayName("Pedido")]
        public int Id { get; set; }

        [DisplayName("Mesa")]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int MesaId { get; set; }

        [DisplayName("Mesa")]
        public IEnumerable<ViewModelDetailsMesa> Mesas { get; set; }

        [DisplayName("Itens")]
        public IEnumerable<ViewModelDetailsItem> Itens { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}