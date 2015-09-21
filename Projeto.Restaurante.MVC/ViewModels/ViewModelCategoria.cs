﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels
{
    public class ViewModelCategoria : ViewModelBase
    {
        #region Propriedades
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Mínimo de {2} e Máximo de {1} caracteres!")]
        public string Nome { get; set; }

        [DisplayName("Pratos")]
        public virtual IEnumerable<ViewModelPrato> Pratos { get; set; }
        #endregion
    }
}