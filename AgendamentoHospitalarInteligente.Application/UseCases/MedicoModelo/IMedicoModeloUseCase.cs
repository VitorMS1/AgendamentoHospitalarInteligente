using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;

namespace AgendamentoHospitalarInteligente.Application.UseCases.MedicoModelo
{
    public interface IMedicoModeloUseCase
    {
        Task<MedicoModeloResponse> ObterPorIdAsync(int id);
        Task<PagedResult<MedicoModeloResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina);
        Task<IEnumerable<MedicoModeloResponse>> BuscarPorNomeAsync(string filtro, int limite);
        Task<MedicoModeloResponse> CriarAsync(CriarMedicoModeloRequest request);
        Task<MedicoModeloResponse> AtualizarAsync(int id, AtualizarMedicoModeloRequest request);
        Task RemoverAsync(int id);
    }
}
