using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Personagens.WebApi.Manha.Domains
{
    public class PersonagemDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório inserir um nome para o persogem")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres, e no máximo 150 caracteres")]
        public string Nome { get; set; }

        public string Lancamento { get; set; }

    }
}
