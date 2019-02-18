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
            if (instituicao == null)
            {
                return NotFound();
            }
            return Ok(instituicao);

        }

        [HttpPost]
        public IActionResult Post(InstituicaoDomain InstituicaoCadastrada)
        {
            try
            {
                InstituicaoRepository.Cadastrar(InstituicaoCadastrada);
                return Ok();
            }
            catch
            {
                return BadRequest("Assim como sua vida, não de");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(InstituicaoDomain InstuicaoCadastrada, int id)
        {
            InstituicaoDomain InstituicaoBuscada = InstituicaoRepository.BuscarId(id);
            
            if(InstituicaoBuscada == null)
            {
                return NotFound();
            }
            try
            {
                InstituicaoRepository.Atualizar(InstuicaoCadastrada, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(InstituicaoDomain InstuicaoCadastrada, int id)
        {
            InstituicaoRepository.Delete(id);
            return Ok();
        }
    }
}
