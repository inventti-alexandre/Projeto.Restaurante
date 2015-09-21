using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Restaurante.MVC.ViewModels
{
    public abstract class ViewModelBase
    {
        #region Propriedades
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid GlobalId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}
