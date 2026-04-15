using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Interfaces;
using AgendamentoHospitalarInteligente.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoHospitalarInteligente.Infrastructure.Repositories
{
    public class MedicoModeloRepository : IMedicoModeloRepository
    {
        private readonly AppDbContext _context;

        public MedicoModeloRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MedicoModelo?> ObterPorIdAsync(int id) =>
            await _context.MedicosModelo
                .Include(m => m.HorariosDisponiveis)
                .FirstOrDefaultAsync(m => m.Id == id);

        public async Task<(IEnumerable<MedicoModelo> Itens, int TotalRegistros)> ObterPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var totalRegistros = await _context.MedicosModelo.CountAsync();

            var itens = await _context.MedicosModelo
                .AsNoTracking()
                .Include(m => m.HorariosDisponiveis)
                .OrderBy(m => m.Id)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return (itens, totalRegistros);
        }

        public async Task<IEnumerable<MedicoModelo>> BuscarPorNomeAsync(string filtro, int limite)
        {
            return await _context.MedicosModelo
                .AsNoTracking()
                .Include(m => m.HorariosDisponiveis)
                .Where(m => m.Nome.Contains(filtro))
                .OrderBy(m => m.Nome)
                .Take(limite)
                .ToListAsync();
        }

        public async Task<MedicoModelo> AdicionarAsync(MedicoModelo medicoModelo)
        {
            await _context.MedicosModelo.AddAsync(medicoModelo);
            await _context.SaveChangesAsync();
            return medicoModelo;
        }

        public async Task AtualizarAsync(MedicoModelo medicoModelo)
        {
            _context.MedicosModelo.Update(medicoModelo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(MedicoModelo medicoModelo)
        {
            _context.MedicosModelo.Remove(medicoModelo);
            await _context.SaveChangesAsync();
        }
    }
}
