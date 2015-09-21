using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels
{
    public class ViewModelItem : ViewModelBase
    {
        #region Propriedades
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int PedidoId { get; set; }

        [DisplayName("Pedido")]
        public virtual ViewModelPedido Pedido { get; set; }
        
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int PratoId { get; set; }

        [DisplayName("Prato")]
        public virtual ViewModelPrato Prato { get; set; }

        [DisplayName("Opções")]
        public virtual IEnumerable<ViewModelOpcao> Opcoes { get; set; }
        #endregion
    }
}
