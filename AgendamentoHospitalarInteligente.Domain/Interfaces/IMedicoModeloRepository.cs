using AgendamentoHospitalarInteligente.Domain.Entities;

namespace AgendamentoHospitalarInteligente.Domain.Interfaces
{
    public interface IMedicoModeloRepository
    {
        Task<MedicoModelo?> ObterPorIdAsync(int id);
        Task<(IEnumerable<MedicoModelo> Itens, int TotalRegistros)> ObterPaginadoAsync(int pagina, int tamanhoPagina);
        Task<IEnumerable<MedicoModelo>> BuscarPorNomeAsync(string filtro, int limite);
        Task<MedicoModelo> AdicionarAsync(MedicoModelo medicoModelo);
        Task AtualizarAsync(MedicoModelo medicoModelo);
        Task RemoverAsync(MedicoModelo medicoModelo);
    }
}
