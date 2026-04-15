using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;
using AgendamentoHospitalarInteligente.Application.Exceptions;
using AgendamentoHospitalarInteligente.Application.Mappings;
using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Interfaces;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.UseCases.MedicoModelo
{
    public class MedicoModeloUseCase : IMedicoModeloUseCase
    {
        private readonly IMedicoModeloRepository _medicoModeloRepository;
        private readonly IValidator<CriarMedicoModeloRequest> _criarValidator;
        private readonly IValidator<AtualizarMedicoModeloRequest> _atualizarValidator;

        public MedicoModeloUseCase(
            IMedicoModeloRepository medicoModeloRepository,
            IValidator<CriarMedicoModeloRequest> criarValidator,
            IValidator<AtualizarMedicoModeloRequest> atualizarValidator)
        {
            _medicoModeloRepository = medicoModeloRepository;
            _criarValidator = criarValidator;
            _atualizarValidator = atualizarValidator;
        }

        public async Task<MedicoModeloResponse> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var medicoModelo = ResourceNotFoundException.WhenNull(
                await _medicoModeloRepository.ObterPorIdAsync(id, cancellationToken),
                $"Médico modelo com Id {id} não encontrado.");

            return medicoModelo.ToResponse();
        }

        public async Task<PagedResult<MedicoModeloResponse>> ObterPaginadoAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
        {
            var (itens, totalRegistros) = await _medicoModeloRepository.ObterPaginadoAsync(pagina, tamanhoPagina, cancellationToken);

            return new PagedResult<MedicoModeloResponse>
            {
                Itens = itens.Select(m => m.ToResponse()),
                TotalRegistros = totalRegistros,
                Pagina = pagina,
                TamanhoPagina = tamanhoPagina
            };
        }

        public async Task<IEnumerable<MedicoModeloResponse>> BuscarPorNomeAsync(string filtro, int limite, CancellationToken cancellationToken = default)
        {
            var itens = await _medicoModeloRepository.BuscarPorNomeAsync(filtro, limite, cancellationToken);
            return itens.Select(m => m.ToResponse());
        }

        public async Task<MedicoModeloResponse> CriarAsync(CriarMedicoModeloRequest request, CancellationToken cancellationToken = default)
        {
            await _criarValidator.ValidateAndThrowAsync(request, cancellationToken);

            var horarios = request.HorariosDisponiveis.Select(h => Horario.CriarDeString(h.Inicio, h.Fim)).ToList();
            var medicoModelo = Domain.Entities.MedicoModelo.Criar(request.Nome, horarios);
            await _medicoModeloRepository.AdicionarAsync(medicoModelo, cancellationToken);
            return medicoModelo.ToResponse();
        }

        public async Task<MedicoModeloResponse> AtualizarAsync(int id, AtualizarMedicoModeloRequest request, CancellationToken cancellationToken = default)
        {
            await _atualizarValidator.ValidateAndThrowAsync(request, cancellationToken);

            var medicoModelo = ResourceNotFoundException.WhenNull(
                await _medicoModeloRepository.ObterPorIdAsync(id, cancellationToken),
                $"Médico modelo com Id {id} não encontrado.");

            var horarios = request.HorariosDisponiveis.Select(h => Horario.CriarDeString(h.Inicio, h.Fim)).ToList();
            medicoModelo.Atualizar(request.Nome, horarios);
            await _medicoModeloRepository.AtualizarAsync(medicoModelo, cancellationToken);
            return medicoModelo.ToResponse();
        }

        public async Task RemoverAsync(int id, CancellationToken cancellationToken = default)
        {
            var medicoModelo = ResourceNotFoundException.WhenNull(
                await _medicoModeloRepository.ObterPorIdAsync(id, cancellationToken),
                $"Médico modelo com Id {id} não encontrado.");

            await _medicoModeloRepository.RemoverAsync(medicoModelo, cancellationToken);
        }
    }
}
