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
        //[DataType(DataType.DateTime, ErrorMessage = "Data Inválida")]
        //[Range(typeof(DateTime), "01/01/1753", "31/12/9999")]
        public DateTime? DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        //[DataType(DataType.DateTime, ErrorMessage = "Data Inválida")]
        //[Range(typeof(DateTime), "01/01/1753", "31/12/9999")]
        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
        #endregion
    }
}
