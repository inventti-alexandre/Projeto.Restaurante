using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.WebApi.ViewModels.Opcao;
using Projeto.Restaurante.WebApi.ViewModels.Prato;

namespace Projeto.Restaurante.WebApi.ViewModels.Item
{
    public class ViewModelGetItem
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public ViewModelDetailsPrato Prato { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public virtual IEnumerable<ViewModelGetOpcao> Opcoes { get; set; }
    }
}