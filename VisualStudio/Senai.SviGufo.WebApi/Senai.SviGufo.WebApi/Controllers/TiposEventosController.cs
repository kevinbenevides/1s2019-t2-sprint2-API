using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositorios;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")] //Define a rota
    [ApiController] //Implementa funcionalidades em nosso controller
    public class TiposEventosController : ControllerBase //Base do controller não possui suporte a view
    {
        List<TipoEventoDomain> tiposeventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain{ Id = 4, Nome = "Design"}
        };

        //Cria um objeto do tipo ITipoEventorepository
        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            //Cria uma instancia de tipoeventorepository
            TipoEventoRepository = new TipoEventoRepository();
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Recebi sua requisição";
        //}

        /// <summary>
        /// Retorna uma lista de eventos
        /// </summary>
        /// <returns>Lista Eventos</returns>

        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepository.Listar();
        }


        /// <summary>
        /// Busca o evento pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorna um Tipo de evento</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEvento = tiposeventos.Find(x => x.Id == id);

            //Verifica se foi encontrado na lista o tipo de evento
            if (tipoEvento == null)
            {
                //retorna não encontrado 
                return NotFound();
            }

            //retorna ok e o tipo de evento
            return Ok(tipoEvento);
        }

        [HttpPost] //Verbo para inserir
        //[FromBody] Pega os dados enviados para a api
        public IActionResult Post(TipoEventoDomain tipoEventoRecebido)
        {
            //Adiciona o tipo de evento recebido na Api
            TipoEventoRepository.Cadastrar(tipoEventoRecebido);

            //Retorna Ok e a lista com os tipos de eventos
            return Ok();
        }

        /*[HttpPut("{id}")] //Verbo para Atualizar
        public IActionResult Put(int id, TipoEventoDomain tipoEventoRecebido )
        {
            return Ok();
        }*/

        [HttpPut] //Verbo para Atualizar
        public IActionResult Put(TipoEventoDomain tipoEventoRecebido)
        {
            TipoEventoRepository.Alterar(tipoEventoRecebido);
            return Ok();
        }

        [HttpDelete ("{id}")]//Verbo para deletar um registro
        public IActionResult Delete(int id)
        {
           TipoEventoRepository.Deletar(id);

            return Ok();
        }
    }
}