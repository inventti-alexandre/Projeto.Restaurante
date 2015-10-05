using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.WebApi.ViewModels.Prato
{
    public class ViewModelGetPrato
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public decimal Preco { get; set; }
    }
}