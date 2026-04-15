using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;
using AgendamentoHospitalarInteligente.Application.Validations;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Application.Validations
{
    public class CriarMedicoModeloRequestValidatorTests
    {
        private readonly CriarMedicoModeloRequestValidator _validator = new();

        [Fact]
        public void Validate_ComDadosValidos_DevePassar()
        {
            var request = new CriarMedicoModeloRequest
            {
                Nome = "Dr. João",
                HorariosDisponiveis = new List<HorarioDto>
                {
                    new() { Inicio = "08:00", Fim = "12:00" }
                }
            };

            var resultado = _validator.Validate(request);

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_SemNome_DeveFalhar()
        {
            var request = new CriarMedicoModeloRequest
            {
                Nome = "",
                HorariosDisponiveis = new List<HorarioDto>
                {
                    new() { Inicio = "08:00", Fim = "12:00" }
                }
            };

            var resultado = _validator.Validate(request);

            resultado.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_SemHorarios_DeveFalhar()
        {
            var request = new CriarMedicoModeloRequest
            {
                Nome = "Dr. João",
                HorariosDisponiveis = new List<HorarioDto>()
            };

            var resultado = _validator.Validate(request);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
