using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels
{
    public class ViewModelPedido : ViewModelBase
    {
        #region Propriedades
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int MesaId { get; set; }

        [DisplayName("Mesa")]
        public virtual ViewModelMesa Mesa { get; set; }

        [DisplayName("Itens")]
        public virtual IEnumerable<ViewModelItem> Itens { get; set; }
        #endregion

    }
}
