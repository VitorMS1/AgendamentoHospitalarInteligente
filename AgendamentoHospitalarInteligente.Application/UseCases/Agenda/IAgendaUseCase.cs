using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;

namespace AgendamentoHospitalarInteligente.Application.UseCases.Agenda
{
    public interface IAgendaUseCase
    {
        Task<AgendaResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PagedResult<AgendaResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
        Task<AgendaResponse> CriarAsync(CriarAgendaRequest request, CancellationToken cancellationToken = default);
        Task<AgendaResponse> EncaixarAsync(int agendaId, EncaixarConsultaRequest request, CancellationToken cancellationToken = default);
        Task RemoverAsync(int id, CancellationToken cancellationToken = default);
    }
}
