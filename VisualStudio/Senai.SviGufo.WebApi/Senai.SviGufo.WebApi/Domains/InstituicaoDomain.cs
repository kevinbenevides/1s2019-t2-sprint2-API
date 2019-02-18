using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set;}

        public string Nome_Fantasia { get; set; }

        [Required(ErrorMessage ="Informe a Razão Social")]
        public string Razao_Social { get; set; }

        public string CNPJ { get; set; }

        public string Logradouro { get; set; }

        public string CEP { get; set; }
        [StringLength(2, MinimumLength = 2,ErrorMessage ="O campo tem que ter 2 caracteres")]
        public string UF { get; set; }

        public string Cidade { get; set; }
    }
}
