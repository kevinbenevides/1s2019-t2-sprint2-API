using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Manha.Domains
{
    [Table("Estudios")]
    public class EstudioDomain
    {
        //Chave Primária
        [Key]
        //Gerar o Id com auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstudioId { get; set; }

        //varchar(150)
        [Column("NomeEstudio", TypeName = "varchar(150)")]
        // not null
        [Required]
        public string NomeEstudio { get; set; }

        public List<JogoDomain> Jogos { get; set; }
    }
}
