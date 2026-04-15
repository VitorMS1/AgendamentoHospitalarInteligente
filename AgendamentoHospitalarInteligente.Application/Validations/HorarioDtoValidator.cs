using AgendamentoHospitalarInteligente.Application.DTOs;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Validations
{
    public class HorarioDtoValidator : AbstractValidator<HorarioDto>
    {
        private const string FormatoHorario = "HH:mm";

        public HorarioDtoValidator()
        {
            RuleFor(x => x.Inicio)
                .NotEmpty().WithMessage("O horário de início é obrigatório.")
                .Must(SerHorarioValido).WithMessage("O horário de início possui formato inválido. Use HH:mm (ex: 08:30).");

            RuleFor(x => x.Fim)
                .NotEmpty().WithMessage("O horário de fim é obrigatório.")
                .Must(SerHorarioValido).WithMessage("O horário de fim possui formato inválido. Use HH:mm (ex: 17:00).");

            RuleFor(x => x)
                .Must(FimPosteriorAoInicio)
                .When(x => SerHorarioValido(x.Inicio) && SerHorarioValido(x.Fim))
                .WithMessage("O horário de fim deve ser posterior ao de início.");
        }

        private static bool SerHorarioValido(string? valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && TimeOnly.TryParseExact(valor.Trim(), FormatoHorario, out _);
        }

        private static bool FimPosteriorAoInicio(HorarioDto dto)
        {
            return TimeOnly.ParseExact(dto.Fim.Trim(), FormatoHorario) > TimeOnly.ParseExact(dto.Inicio.Trim(), FormatoHorario);
        }
    }
}
