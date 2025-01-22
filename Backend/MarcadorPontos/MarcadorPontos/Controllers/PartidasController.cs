using Application.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MarcadorPontos.Controllers
{
    [Route("api/partidas")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly IPartidaApplication _application;
        public PartidasController(IPartidaApplication application) => _application = application;

        [HttpGet]
        public virtual IActionResult GetResults()
        {
            try
            {
                return Ok(_application.GetResults());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor.", detalhe = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] Partida partida)
        {
            try
            {
                if (partida is not null)
                    _application.Add(partida);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = "Erro interno no servidor.", detalhe = ex.InnerException?.Message ?? ex.Message });
            }
               
        }
    }
}
