using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    public class PacoteDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacoteId { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string NomePacote { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataIda { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataVolta { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Valor { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public Boolean Ativo { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string NomeCidade { get; set; }
    }
}
