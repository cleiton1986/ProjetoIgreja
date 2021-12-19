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
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        public readonly IEventoApp _eventoApp;
        public HomeController(IEventoApp eventoApp)
        {
            _eventoApp = eventoApp;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAllImagens()
        {
            //ActionResult = Retorna o status code do Http e tb posso especificar o tipo
            //ex: 200, 404

            try
            {
                var imagens = await _eventoApp.GetAllEventosImagensByAsync();
                if (imagens == null) return NotFound(this.StatusCode(StatusCodes.Status404NotFound));

                return Ok(imagens);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                         $"Erro ao tentar recuperar eventos, erro: {ex.Message}");
            }
        }
    }
}
