﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChessTournaments.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            ListaFotos = new HashSet<Fotografia>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Primeiro Nome da Pessoa
        /// </summary>

        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Primeiro_Nome { get; set; }

        /// <summary>
        /// Útlimo Nome da Pessoa
        /// </summary>

        [Display(Name = "Último Nome")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Ultimo_Nome { get; set; }

        ///<summary>
        ///Nome do Utilizador da Pessoa
        /// </summary>

        [Display(Name = "Nome do Utilizador")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Username { get; set; }

        /// <summary>
        /// Password da Pessoa
        /// </summary> 
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Password { get; set; }

        /// <summary>
        /// Data de nascimento da Pessoa
        /// </summary>

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo da Pessoa
        /// </summary> 
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Sexo { get; set; }

        ///<summary>
        ///Nacionalidade da Pessoa
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Email da Pessoa
        /// </summary>
        [EmailAddress(ErrorMessage = "O {0} não está corretamente escrito")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Email { get; set; }

        /// <summary>
        /// Telemóvel da Pessoa
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Telemóvel")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter {1} dígitos.")]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "O número de {0} deve começar por 91, 92, 93 ou 96, e ter 9 dígitos")]
        public string Telemovel { get; set; }

        /// <summary>
        /// Morada da Pessoa 
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Morada { get; set; }

        /// <summary>
        /// Código Postal da Morada da Pessoa
        /// </summary>
        [DisplayName("Código Postal")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "O {0} deve ter {1} dígitos.")]
        [RegularExpression("[1-9]{1}[0-9]{3}-[0-9]{3}", ErrorMessage = "O {0} deve ter o formato XXXX-XXX")]
        public string CodPostal { get; set; }


        /// <summary>
        /// Atribuição do Funcionário
        /// S - Sim
        /// N - Não
        /// </summary>

        [Display(Name = "Funcionário")]
        public string isFuncionario { get; set; }

        /*******************APLICÁVEL APENAS A JOGADORES*****************************/

        [ForeignKey(nameof(Equipa))]
        [Display(Name = "Equipa")]

        public int EquipaFK { get; set; }

        public Equipa Equipa { get; set; }

        /// <summary>
        /// Pontuação Global do Jogador
        /// </summary>
        /// 
        [Display(Name = "Pontuação")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public int Score { get; set; }

        /// <summary>
        /// Lista das Fotografias associadas a uma Pessoa
        /// </summary>
        public ICollection<Fotografia> ListaFotos { get; set; }
    }
}
