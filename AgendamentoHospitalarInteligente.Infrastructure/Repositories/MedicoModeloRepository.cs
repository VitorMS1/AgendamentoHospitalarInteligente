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

        public async Task<MedicoModelo?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.MedicosModelo
                .Include(m => m.HorariosDisponiveis)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<MedicoModelo> Itens, int TotalRegistros)> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
        {
            var totalRegistros = await _context.MedicosModelo.CountAsync(cancellationToken);

            var itens = await _context.MedicosModelo
                .AsNoTracking()
                .Include(m => m.HorariosDisponiveis)
                .OrderBy(m => m.Id)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync(cancellationToken);

            return (itens, totalRegistros);
        }

        public async Task<IEnumerable<MedicoModelo>> BuscarPorNomeAsync(string filtro, int limite, CancellationToken cancellationToken = default)
        {
            return await _context.MedicosModelo
                .AsNoTracking()
                .Include(m => m.HorariosDisponiveis)
                .Where(m => m.Nome.Contains(filtro))
                .OrderBy(m => m.Nome)
                .Take(limite)
                .ToListAsync(cancellationToken);
        }

        public async Task<MedicoModelo> AdicionarAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default)
        {
            await _context.MedicosModelo.AddAsync(medicoModelo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return medicoModelo;
        }

        public async Task AtualizarAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default)
        {
            _context.MedicosModelo.Update(medicoModelo);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoverAsync(MedicoModelo medicoModelo, CancellationToken cancellationToken = default)
        {
            _context.MedicosModelo.Remove(medicoModelo);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
