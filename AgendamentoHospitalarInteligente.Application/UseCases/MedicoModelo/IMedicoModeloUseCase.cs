using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;

namespace AgendamentoHospitalarInteligente.Application.UseCases.MedicoModelo
{
    public interface IMedicoModeloUseCase
    {
        Task<MedicoModeloResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PagedResult<MedicoModeloResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
        Task<IEnumerable<MedicoModeloResponse>> BuscarPorNomeAsync(string filtro, int limite, CancellationToken cancellationToken = default);
        Task<MedicoModeloResponse> CriarAsync(CriarMedicoModeloRequest request, CancellationToken cancellationToken = default);
        Task<MedicoModeloResponse> AtualizarAsync(int id, AtualizarMedicoModeloRequest request, CancellationToken cancellationToken = default);
        Task RemoverAsync(int id, CancellationToken cancellationToken = default);
    }
}
