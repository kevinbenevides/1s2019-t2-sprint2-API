using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.CodeFirst.WebApi.Manha.Domains;
using Senai.InLock.CodeFirst.WebApi.Manha.Interfaces;
using Senai.InLock.CodeFirst.WebApi.Manha.Repositorios;

namespace Senai.InLock.CodeFirst.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepository { get; set; }

        public JogosController()
        {
            JogoRepository = new JogoRepository();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(JogoRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(JogoDomain jogo)
        {
            try
            {
                JogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int id, JogoDomain jogo)
        {
            try
            {
                JogoRepository.Atualizar(id, jogo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}