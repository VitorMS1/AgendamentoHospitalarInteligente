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
        public async Task<IActionResult> ObterPorId(int id, CancellationToken cancellationToken)
        {
            var resultado = await _useCase.ObterPorIdAsync(id, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string filtro = "", [FromQuery] int limite = 10, CancellationToken cancellationToken = default)
        {
            var resultado = await _useCase.BuscarPorNomeAsync(filtro, limite, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPaginado([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10, CancellationToken cancellationToken = default)
        {
            var resultado = await _useCase.ObterPaginadoAsync(pagina, tamanhoPagina, cancellationToken);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarMedicoModeloRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _useCase.CriarAsync(request, cancellationToken);
            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarMedicoModeloRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _useCase.AtualizarAsync(id, request, cancellationToken);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id, CancellationToken cancellationToken)
        {
            await _useCase.RemoverAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
