using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage =  "Email Incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage =  "Senha Incorreta")]
        public string Senha { get; set; }
    }
}
