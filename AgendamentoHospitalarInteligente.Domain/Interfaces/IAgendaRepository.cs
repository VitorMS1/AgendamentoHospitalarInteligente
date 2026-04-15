using AgendamentoHospitalarInteligente.Domain.Entities;

namespace AgendamentoHospitalarInteligente.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<Agenda?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Agenda> Itens, int TotalRegistros)> ObterPaginadoResumidoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
        Task<Agenda> AdicionarAsync(Agenda agenda, CancellationToken cancellationToken = default);
        Task AtualizarAsync(Agenda agenda, CancellationToken cancellationToken = default);
        Task RemoverAsync(Agenda agenda, CancellationToken cancellationToken = default);
    }
}
