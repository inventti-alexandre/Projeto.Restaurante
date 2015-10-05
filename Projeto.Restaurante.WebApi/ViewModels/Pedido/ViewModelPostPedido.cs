using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.WebApi.ViewModels.Pedido
{
    public class ViewModelPostPedido
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int Id { get; set; }
    }
}