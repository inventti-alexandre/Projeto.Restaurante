using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.WebApi.ViewModels.Opcao;
using Projeto.Restaurante.WebApi.ViewModels.Pedido;
using Projeto.Restaurante.WebApi.ViewModels.Prato;

namespace Projeto.Restaurante.WebApi.ViewModels.Item
{
    public class ViewModelPostItem
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public ViewModelPostPedido Pedido { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public ViewModelPostPrato Prato { get; set; }

        public virtual IList<ViewModelPostOpcao> Opcoes { get; set; }
    }
}