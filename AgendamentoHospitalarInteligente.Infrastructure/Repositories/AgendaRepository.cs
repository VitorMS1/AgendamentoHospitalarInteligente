using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Interfaces;
using AgendamentoHospitalarInteligente.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoHospitalarInteligente.Infrastructure.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AppDbContext _context;

        public AgendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Agenda?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Agendas
                .Include(a => a.Medicos)
                .Include(a => a.Consultas).ThenInclude(c => c.Medico)
                .Include(a => a.PacientesNaoAlocados)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<(IEnumerable<Agenda> Itens, int TotalRegistros)> ObterPaginadoResumidoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
        {
            var totalRegistros = await _context.Agendas.CountAsync(cancellationToken);

            var itens = await _context.Agendas
                .AsNoTracking()
                .OrderByDescending(a => a.Data)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync(cancellationToken);

            return (itens, totalRegistros);
        }

        public async Task<Agenda> AdicionarAsync(Agenda agenda, CancellationToken cancellationToken = default)
        {
            await _context.Agendas.AddAsync(agenda, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return agenda;
        }

        public async Task AtualizarAsync(Agenda agenda, CancellationToken cancellationToken = default)
        {
            _context.Agendas.Update(agenda);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoverAsync(Agenda agenda, CancellationToken cancellationToken = default)
        {
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
