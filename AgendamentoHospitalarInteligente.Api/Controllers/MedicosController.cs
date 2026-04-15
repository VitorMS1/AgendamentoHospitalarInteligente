using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;
using AgendamentoHospitalarInteligente.Application.UseCases.MedicoModelo;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoHospitalarInteligente.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoModeloUseCase _useCase;

        public MedicosController(IMedicoModeloUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var resultado = await _useCase.ObterPorIdAsync(id);
            return Ok(resultado);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string filtro = "", [FromQuery] int limite = 10)
        {
            var resultado = await _useCase.BuscarPorNomeAsync(filtro, limite);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPaginado([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            var resultado = await _useCase.ObterPaginadoAsync(pagina, tamanhoPagina);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarMedicoModeloRequest request)
        {
            var resultado = await _useCase.CriarAsync(request);
            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarMedicoModeloRequest request)
        {
            var resultado = await _useCase.AtualizarAsync(id, request);
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
