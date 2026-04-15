using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using AgendamentoHospitalarInteligente.Application.Exceptions;
using AgendamentoHospitalarInteligente.Application.Mappings;
using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Interfaces;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.UseCases.Agenda
{
    public class AgendaUseCase : IAgendaUseCase
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IValidator<CriarAgendaRequest> _criarValidator;
        private readonly IValidator<EncaixarConsultaRequest> _encaixarValidator;

        public AgendaUseCase(
            IAgendaRepository agendaRepository,
            IValidator<CriarAgendaRequest> criarValidator,
            IValidator<EncaixarConsultaRequest> encaixarValidator)
        {
            _agendaRepository = agendaRepository;
            _criarValidator = criarValidator;
            _encaixarValidator = encaixarValidator;
        }

        public async Task<AgendaResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var agenda = ResourceNotFoundException.WhenNull(
                await _agendaRepository.ObterPorIdAsync(id, cancellationToken),
                $"Agenda com Id {id} não encontrada.");

            return agenda.ToResponse();
        }

        public async Task<PagedResult<AgendaResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
        {
            var (itens, totalRegistros) = await _agendaRepository.ObterPaginadoResumidoAsync(pagina, tamanhoPagina, cancellationToken);

            return new PagedResult<AgendaResponse>
            {
                Itens = itens.Select(a => a.ToResponse()),
                TotalRegistros = totalRegistros,
                Pagina = pagina,
                TamanhoPagina = tamanhoPagina
            };
        }

        public async Task<AgendaResponse> CriarAsync(CriarAgendaRequest request, CancellationToken cancellationToken = default)
        {
            await _criarValidator.ValidateAndThrowAsync(request, cancellationToken);

            var medicosAlocados = request.Medicos.ToDomain();
            var solicitacoes = request.Solicitacoes.ToDomain();
            var agora = ParseHoraAtual(request.HoraAtual);

            var agenda = Domain.Entities.Agenda.Criar(medicosAlocados, solicitacoes, DateTime.Now, agora);
            await _agendaRepository.AdicionarAsync(agenda, cancellationToken);

            return agenda.ToResponse();
        }

        public async Task<AgendaResponse> EncaixarAsync(int agendaId, EncaixarConsultaRequest request, CancellationToken cancellationToken = default)
        {
            await _encaixarValidator.ValidateAndThrowAsync(request, cancellationToken);

            var agenda = ResourceNotFoundException.WhenNull(
                await _agendaRepository.ObterPorIdAsync(agendaId, cancellationToken),
                $"Agenda com Id {agendaId} não encontrada.");

            var solicitacao = PacienteNaoAlocado.Criar(request.PacienteNome, TimeSpan.FromMinutes(request.DuracaoMinutos), request.Prioridade);

            var agora = ParseHoraAtual(request.HoraAtual);
            agenda.Encaixar(solicitacao, agora);
            await _agendaRepository.AtualizarAsync(agenda, cancellationToken);

            return agenda.ToResponse();
        }

        public async Task RemoverAsync(int id, CancellationToken cancellationToken = default)
        {
            var agenda = ResourceNotFoundException.WhenNull(
                await _agendaRepository.ObterPorIdAsync(id, cancellationToken),
                $"Agenda com Id {id} não encontrada.");

            await _agendaRepository.RemoverAsync(agenda, cancellationToken);
        }

        private static TimeOnly ParseHoraAtual(string? horaAtual)
        {
            if (string.IsNullOrWhiteSpace(horaAtual))
                return TimeOnly.MinValue;

            return TimeOnly.ParseExact(horaAtual.Trim(), "HH:mm");
        }
    }
}
