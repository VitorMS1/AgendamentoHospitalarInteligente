using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Validations
{
    public class CriarAgendaRequestValidator : AbstractValidator<CriarAgendaRequest>
    {
        public CriarAgendaRequestValidator()
        {
            RuleFor(x => x.Medicos)
                .NotEmpty().WithMessage("A lista de médicos deve conter pelo menos um item.");

            RuleForEach(x => x.Medicos)
                .SetValidator(new MedicoAgendaDtoValidator());

            RuleFor(x => x.Solicitacoes)
                .NotEmpty().WithMessage("A lista de solicitações deve conter pelo menos um item.");

            RuleForEach(x => x.Solicitacoes)
                .SetValidator(new SolicitacaoDtoValidator());
        }
    }
}
