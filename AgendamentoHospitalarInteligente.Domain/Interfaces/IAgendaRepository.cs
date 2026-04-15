using AgendamentoHospitalarInteligente.Domain.Entities;

namespace AgendamentoHospitalarInteligente.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        Task<Agenda?> ObterPorIdAsync(int id);
        Task<(IEnumerable<Agenda> Itens, int TotalRegistros)> ObterPaginadoResumidoAsync(int pagina, int tamanhoPagina);
        Task<Agenda> AdicionarAsync(Agenda agenda);
        Task AtualizarAsync(Agenda agenda);
        Task RemoverAsync(Agenda agenda);
    }
}
