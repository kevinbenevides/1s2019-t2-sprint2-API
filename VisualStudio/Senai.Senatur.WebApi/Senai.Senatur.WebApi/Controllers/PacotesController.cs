using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using Senai.Senatur.WebApi.Repositorio;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacoteRepository PacoteRepository { get; set; }

        public PacotesController()
        {
            PacoteRepository = new PacoteRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(PacoteRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarporId(int id)
        {
            try
            {
                
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(PacoteDomain pacote)
        {
            try
            {
                PacoteRepository.Cadastrar(pacote);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int id, PacoteDomain pacote)
        {
            try
            {
                PacoteRepository.Atualizar(id, pacote);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}