using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Validations
{
    public class CriarMedicoModeloRequestValidator : AbstractValidator<CriarMedicoModeloRequest>
    {
        public CriarMedicoModeloRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do médico modelo é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do médico modelo não pode exceder 100 caracteres.");

            RuleFor(x => x.HorariosDisponiveis)
                .NotEmpty().WithMessage("O médico modelo deve ter pelo menos um horário disponível.");

            RuleForEach(x => x.HorariosDisponiveis)
                .SetValidator(new HorarioDtoValidator());
        }
    }
}
