using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.WebApi.ViewModels.Opcao;

namespace Projeto.Restaurante.WebApi.ViewModels.Item
{
    public class ViewModelPostItem
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int PratoId { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public virtual IList<ViewModelPostOpcao> Opcoes { get; set; }
    }
}