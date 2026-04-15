using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Validations
{
    public class EncaixarConsultaRequestValidator : AbstractValidator<EncaixarConsultaRequest>
    {
        public EncaixarConsultaRequestValidator()
        {
            RuleFor(x => x.PacienteNome)
                .NotEmpty().WithMessage("O nome do paciente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do paciente não pode exceder 100 caracteres.");

            RuleFor(x => x.DuracaoMinutos)
                .GreaterThan(0).WithMessage("A duração da consulta deve ser maior que zero.")
                .LessThanOrEqualTo(1440).WithMessage("A duração da consulta não pode exceder 1440 minutos (24 horas).");

            RuleFor(x => x.Prioridade)
                .IsInEnum().WithMessage("Prioridade inválida. Valores aceitos: Baixa, Media, Alta.");
        }
    }
}
