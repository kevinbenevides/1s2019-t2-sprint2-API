using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Personagens.WebApi.Manha.Domains;
using Senai.Personagens.WebApi.Manha.Interfaces;
using Senai.Personagens.WebApi.Manha.Repositorios;

namespace Senai.Personagens.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository PersonagemRepository { get; set; }


        public PersonagensController()
        {
            PersonagemRepository = new PersonagemRepository();
        }

        [HttpGet]
        public IEnumerable<PersonagemDomain> Get()
        {
            return PersonagemRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(PersonagemDomain PersonagemCadastrado)
        {
            try
            {
                PersonagemRepository.Cadastrar(PersonagemCadastrado);
                return Ok("Tudo Certo");
            }
            catch
            {
                return BadRequest("Deu problema!");
            }
        }
    }
}