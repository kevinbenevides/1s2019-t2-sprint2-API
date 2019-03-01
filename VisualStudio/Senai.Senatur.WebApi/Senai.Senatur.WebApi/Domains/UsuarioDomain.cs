using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Domains
{
    public class UsuarioDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(250)")]
        [MinLength(6)]
        [Required]
        public string Senha { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string TipoUsuario { get; set; }
    }
}
