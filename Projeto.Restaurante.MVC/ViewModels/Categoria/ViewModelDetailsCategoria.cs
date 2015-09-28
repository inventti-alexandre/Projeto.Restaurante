using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Projeto.Restaurante.MVC.ViewModels.Prato;

namespace Projeto.Restaurante.MVC.ViewModels.Categoria
{
    public class ViewModelDetailsCategoria
    {
        #region Propriedades
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Mínimo de {2} e Máximo de {1} caracteres!")]
        public string Nome { get; set; }

        [DisplayName("Pratos")]
        public IEnumerable<ViewModelDetailsPrato> Pratos { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}