using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels.Prato
{
    public class ViewModelCreatePrato
    {
        #region Propriedades
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Mínimo de {2} e Máximo de {1} caracteres!")]
        public string Nome { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [Range(typeof(decimal), "0", "999999")]
        public decimal Preco { get; set; }

        [DisplayName("Descrição")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Mínimo de {2} e Máximo de {1} caracteres!")]
        public string Descricao { get; set; }

        [DisplayName("Disponível?")]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public bool Disponivel { get; set; }
        
        public bool Ativo { get; set; }
        #endregion
    }
}