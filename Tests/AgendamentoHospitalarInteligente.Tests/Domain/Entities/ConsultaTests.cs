using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Domain.Entities
{
    public class ConsultaTests
    {
        private static MedicoAlocado MedicoPadrao()
        {
            return MedicoAlocado.Criar("Dr. João",
                new List<Horario> { new(new TimeOnly(8, 0), new TimeOnly(12, 0)) });
        }

        [Fact]
        public void Criar_ComDadosValidos_DeveInstanciarConsulta()
        {
            var medico = MedicoPadrao();
            var horario = new Horario(new TimeOnly(8, 0), new TimeOnly(8, 30));

            var consulta = Consulta.Criar(medico, "Ana", TimeSpan.FromMinutes(30), Prioridade.Alta, horario);

            consulta.Medico.Should().Be(medico);
            consulta.PacienteNome.Should().Be("Ana");
            consulta.Duracao.Should().Be(TimeSpan.FromMinutes(30));
            consulta.Prioridade.Should().Be(Prioridade.Alta);
            consulta.Horario.Should().Be(horario);
        }

        [Fact]
        public void Criar_ComDuracaoZero_DeveLancarExcecao()
        {
            var medico = MedicoPadrao();
            var horario = new Horario(new TimeOnly(8, 0), new TimeOnly(8, 30));

            Action acao = () => Consulta.Criar(medico, "Ana", TimeSpan.Zero, Prioridade.Alta, horario);

            acao.Should().Throw<DomainValidationException>();
        }

        [Fact]
        public void AtualizarHorario_DeveAlterarHorarioDaConsulta()
        {
            var medico = MedicoPadrao();
            var consulta = Consulta.Criar(medico, "Ana", TimeSpan.FromMinutes(30), Prioridade.Alta,
                new Horario(new TimeOnly(8, 0), new TimeOnly(8, 30)));

            var novoHorario = new Horario(new TimeOnly(10, 0), new TimeOnly(10, 30));
            consulta.AtualizarHorario(novoHorario);

            consulta.Horario.Should().Be(novoHorario);
        }
    }
}
