﻿using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.WebApi.ViewModels.Opcao
{
    public class ViewModelPostOpcao
    {
        [Required(ErrorMessage = "Obrigatório!", AllowEmptyStrings = false)]
        public int Id { get; set; }
    }
}