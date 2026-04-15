using AgendamentoHospitalarInteligente.Domain.Entities;

namespace AgendamentoHospitalarInteligente.Domain.Interfaces
{
    public interface IMedicoModeloRepository
    {
        Task<MedicoModelo?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<(IEnumerable<MedicoModelo> Itens, int TotalRegistros)> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
        Task<IEnumerable<MedicoModelo>> BuscarPorNomeAsync(string filtro, int limite, CancellationToken cancellationToken = default);
        Task<MedicoModelo> AdicionarAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default);
        Task AtualizarAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default);
        Task RemoverAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default);
    }
}
