using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int JogoId { get; set;}
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeJogo { get; set; }

        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        //[DataType("dd/mm/aaaa", ErrorMessage ="Formato de Data Inválido")]
        public DateTime DataLancamento { get; set; }

        public decimal Valor { get; set; }

        public EstudioDomain Estudio { get; set; }

        public int EstudioId { get; set; }
    }
}