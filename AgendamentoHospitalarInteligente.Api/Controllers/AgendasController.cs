using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using AgendamentoHospitalarInteligente.Application.UseCases.Agenda;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospitalarInteligente.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaUseCase _useCase;

        public AgendasController(IAgendaUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var resultado = await _useCase.ObterPorIdAsync(id);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPaginado([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            var resultado = await _useCase.ObterPaginadoAsync(pagina, tamanhoPagina);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarAgendaRequest request)
        {
            var resultado = await _useCase.CriarAsync(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPost("{id}/encaixar")]
        public async Task<IActionResult> Encaixar(int id, [FromBody] EncaixarConsultaRequest request)
        {
            var resultado = await _useCase.EncaixarAsync(id, request);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _useCase.RemoverAsync(id);
            return NoContent();
        }
    }
}
