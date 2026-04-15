using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Domain.ValueObjects
{
    public class HorarioTests
    {
        [Fact]
        public void Criar_ComInicioAnteriorAoFim_DeveCriarHorarioValido()
        {
            var horario = new Horario(new TimeOnly(8, 0), new TimeOnly(12, 0));

            horario.Inicio.Should().Be(new TimeOnly(8, 0));
            horario.Fim.Should().Be(new TimeOnly(12, 0));
        }

        [Fact]
        public void Criar_ComFimIgualAoInicio_DeveLancarExcecao()
        {
            Action acao = () => new Horario(new TimeOnly(8, 0), new TimeOnly(8, 0));

            acao.Should().Throw<DomainValidationException>()
                .WithMessage("*posterior*");
        }

        [Fact]
        public void Criar_ComFimAnteriorAoInicio_DeveLancarExcecao()
        {
            Action acao = () => new Horario(new TimeOnly(12, 0), new TimeOnly(8, 0));

            acao.Should().Throw<DomainValidationException>();
        }

        [Fact]
        public void CriarDeString_ComStringsValidas_DeveConstruirHorario()
        {
            var horario = Horario.CriarDeString("08:00", "09:30");

            horario.Inicio.Should().Be(new TimeOnly(8, 0));
            horario.Fim.Should().Be(new TimeOnly(9, 30));
        }

        [Fact]
        public void Contem_QuandoOutroEstaDentroDoHorario_DeveRetornarTrue()
        {
            var maior = new Horario(new TimeOnly(8, 0), new TimeOnly(12, 0));
            var menor = new Horario(new TimeOnly(9, 0), new TimeOnly(10, 0));

            maior.Contem(menor).Should().BeTrue();
        }

        [Fact]
        public void Contem_QuandoOutroUltrapassaFim_DeveRetornarFalse()
        {
            var atual = new Horario(new TimeOnly(8, 0), new TimeOnly(10, 0));
            var outro = new Horario(new TimeOnly(9, 0), new TimeOnly(11, 0));

            atual.Contem(outro).Should().BeFalse();
        }
    }
}
