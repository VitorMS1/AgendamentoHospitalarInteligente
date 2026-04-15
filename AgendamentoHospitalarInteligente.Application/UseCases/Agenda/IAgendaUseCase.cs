using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;

namespace AgendamentoHospitalarInteligente.Application.UseCases.Agenda
{
    public interface IAgendaUseCase
    {
        Task<AgendaResponse> ObterPorIdAsync(int id);
        Task<PagedResult<AgendaResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina);
        Task<AgendaResponse> CriarAsync(CriarAgendaRequest request);
        Task<AgendaResponse> EncaixarAsync(int agendaId, EncaixarConsultaRequest request);
        Task RemoverAsync(int id);
    }
}
