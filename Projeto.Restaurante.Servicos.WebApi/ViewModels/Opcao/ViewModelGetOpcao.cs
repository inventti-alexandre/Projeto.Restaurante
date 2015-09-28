using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.Servicos.WebApi.ViewModels.Opcao
{
    public class ViewModelGetOpcao
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public string Nome { get; set; }
    }
}