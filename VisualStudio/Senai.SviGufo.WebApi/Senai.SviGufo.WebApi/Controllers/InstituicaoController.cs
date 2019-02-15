using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositorios;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class InstituicaoController : ControllerBase
    {

        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicaoController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IEnumerable<InstituicaoDomain> Get()
        {
            return InstituicaoRepository.Listar();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            InstituicaoDomain instituicao = InstituicaoRepository.BuscarId(id);

            return Ok(instituicao);

        }

        [HttpPost]
        public IActionResult Post(InstituicaoDomain InstituicaoCadastrada)
        {
            InstituicaoRepository.Cadastrar(InstituicaoCadastrada);
            return Ok();
        }
        
    }
}
