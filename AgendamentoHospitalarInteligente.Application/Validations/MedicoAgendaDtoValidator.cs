using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Validations
{
    public class MedicoAgendaDtoValidator : AbstractValidator<MedicoAgendaDto>
    {
        public MedicoAgendaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do médico é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do médico não pode exceder 100 caracteres.");

            RuleFor(x => x.HorariosDisponiveis)
                .NotEmpty().WithMessage("O médico deve ter pelo menos um horário disponível.");

            RuleForEach(x => x.HorariosDisponiveis)
                .SetValidator(new HorarioDtoValidator());
        }
    }
}
