﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels.Opcao
{
    public class ViewModelCreateOpcao
    {
        #region Propriedades
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de {2} e Máximo de {1} caracteres!")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}