using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.WebApi.ViewModels.Prato
{
    public class ViewModelPostPrato
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int Id { get; set; }
    }
}