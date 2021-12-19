using IgrejaJdLilah.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace IgrejaJdLilah.API.Controllers
{
  
   // [Route("api/[controller]")]
    [ApiController]
    //[Authorize("PortalMagistraturaAPI")]
    //[EnableCors]
    [Route("api/contato")]
    public class ContatoController : Controller
    {
        public readonly IContatoApp _contatoApp;
        public ContatoController(IContatoApp contatoApp)
        {
            _contatoApp = contatoApp;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetById(int id)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var evento = await _contatoApp.GetContatoByContatoIdAsync(id, true);
                if (evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar recuperar contato, erro: {ex.Message}");
            }
        }

        [HttpGet("denominacao/{denominacao}")]
        public async Task<ActionResult<Contato>> GetByDenominacao(string denominacao)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var evento = await _contatoApp.GetAllContatoByDenominacaoAsync(denominacao, true);
                if (evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar recuperar contato, erro: {ex.Message}");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Contato>> GetByEmail(string email)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var evento = await _contatoApp.GetContatoByEmailAsync(email, true);
                if (evento == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar recuperar contato, erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contato model)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var contato = await _contatoApp.AddContato(model);
                if (contato == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar inserir o contato, erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Contato model)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var contato = await _contatoApp.AlterarContato(model);
                if (contato == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar atualizar o contato, erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                return await _contatoApp.ExcluirContato(id) ?
                                        Ok("Deletado") :
                                        BadRequest("Contato não Deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar inserir o eventos, erro: {ex.Message}");
            }
        }

    }
}
