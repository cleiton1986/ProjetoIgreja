using System.Collections.Generic;
using System.Linq;
using IgrejaJdLilah.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using IgrejaJdLilah.Persistence.Contexto;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace IgrejaJdLilah.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public readonly IEventoApp _eventoApp;
        public EventosController(IEventoApp eventoApp)
        {
            _eventoApp = eventoApp;
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<Evento>> GetById(int id)
        {
           //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404
           
            try 
            {
               var evento = await _eventoApp.GetEventoByIdAsync(id, true);
               if(evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));
               
               return Ok(evento);
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar recuperar eventos, erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //IActionResult = Retorna o status code do Http
            //ex: 200, 404
           
            try 
            {
               var evento = await _eventoApp.GetAllEventosByAsync(true);
               if(evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));
               
               return Ok(evento);
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar recuperar eventos, erro: {ex.Message}");
            }
        }
        [HttpGet("tema/{tema}")]
        public  async Task<IActionResult> GetByTema(string tema)
        {
           //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404
           
            try 
            {
               var evento = await _eventoApp.GetAllEventosByTemaAsync(tema, true);
               if(evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));
               
               return Ok(evento);
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar recuperar eventos, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404
           
            try 
            {
               var evento = await _eventoApp.AddEvento(model);
               if(evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));
               
               return Ok(evento);
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar inserir o eventos, erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Evento model)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404
           
            try 
            {
               var evento = await _eventoApp.AleterarEvento(model);
               if(evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));
               
               return Ok(evento);
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar atualizar o eventos, erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404
           
            try 
            {
                return await _eventoApp.ExcluirEvento(id) ? 
                                        Ok("Deletado") : 
                                        BadRequest("Evento não Deletado");
            }
            catch(Exception ex)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                        $"Erro ao tentar inserir o eventos, erro: {ex.Message}");
            }
        }
    }
}
