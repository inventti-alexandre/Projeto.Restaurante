using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.MVC.ViewModels.Mesa;

namespace Projeto.Restaurante.MVC.ViewModels.Pedido
{
    public class ViewModelCreatePedido
    {
        #region Propriedades
        [DisplayName("Mesa")]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int MesaId { get; set; }

        [DisplayName("Mesa")]
        public IEnumerable<ViewModelDetailsMesa> Mesas { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}