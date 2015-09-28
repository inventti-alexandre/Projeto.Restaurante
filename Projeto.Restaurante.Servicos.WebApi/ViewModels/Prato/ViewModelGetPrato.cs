using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.Servicos.WebApi.ViewModels.Prato
{
    public class ViewModelDetailsPrato
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public decimal Preco { get; set; }
    }
}