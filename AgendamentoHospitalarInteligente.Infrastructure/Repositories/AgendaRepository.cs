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

        public async Task<Agenda?> ObterPorIdAsync(int id) =>
            await _context.Agendas
                .Include(a => a.Medicos)
                .Include(a => a.Consultas).ThenInclude(c => c.Medico)
                .Include(a => a.PacientesNaoAlocados)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<(IEnumerable<Agenda> Itens, int TotalRegistros)> ObterPaginadoResumidoAsync(int pagina, int tamanhoPagina)
        {
            var totalRegistros = await _context.Agendas.CountAsync();

            var itens = await _context.Agendas
                .AsNoTracking()
                .OrderByDescending(a => a.Data)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return (itens, totalRegistros);
        }

        public async Task<Agenda> AdicionarAsync(Agenda agenda)
        {
            await _context.Agendas.AddAsync(agenda);
            await _context.SaveChangesAsync();
            return agenda;
        }

        public async Task AtualizarAsync(Agenda agenda)
        {
            _context.Agendas.Update(agenda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Agenda agenda)
        {
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
        }
    }
}
