using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.Validations;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Application.Validations
{
    public class HorarioDtoValidatorTests
    {
        private readonly HorarioDtoValidator _validator = new();

        [Theory]
        [InlineData("08:00", "12:00")]
        [InlineData("08:30", "08:31")]
        public void Validate_ComHorariosValidos_DevePassar(string inicio, string fim)
        {
            var resultado = _validator.Validate(new HorarioDto { Inicio = inicio, Fim = fim });

            resultado.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validate_ComFormatoInvalido_DeveFalhar()
        {
            var resultado = _validator.Validate(new HorarioDto { Inicio = "8h", Fim = "9h" });

            resultado.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_ComFimAnteriorAoInicio_DeveFalhar()
        {
            var resultado = _validator.Validate(new HorarioDto { Inicio = "10:00", Fim = "08:00" });

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.ErrorMessage.Contains("posterior"));
        }

        [Fact]
        public void Validate_ComCamposVazios_DeveFalhar()
        {
            var resultado = _validator.Validate(new HorarioDto { Inicio = "", Fim = "" });

            resultado.IsValid.Should().BeFalse();
        }
    }
}
