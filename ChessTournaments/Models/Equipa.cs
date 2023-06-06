using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChessTournaments.Models
{
    public class Equipa
    {
        public int Id { get; set; }

        ///<summary>
        ///Nome da Equipa
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Morada da Organização
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Morada { get; set; }

        ///<<summary>
        ///Código Postal da Organização
        /// </summary>
        [Display(Name = "Código Postal")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "O {0} deve ter {1} dígitos.")]
        [RegularExpression("[1-9]{1}[0-9]{3}-[0-9]{3}[A-Za-z]", ErrorMessage = "O {0} deve ter o formato XXXX-XXX")]
        public string CodigoPostal { get; set; }

        ///<summary>
        ///Data de Fundação da Equipa
        ///</summary>

        [Display(Name = "Data da Fundação")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dataFundacao { get; set; }
    }
}
