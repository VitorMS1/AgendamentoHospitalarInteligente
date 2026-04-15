using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Domain.Entities
{
    public class AgendaTests
    {
        private static MedicoAlocado MedicoPadrao() =>
            MedicoAlocado.Criar("Dr. João", new List<Horario> { new(new TimeOnly(8, 0), new TimeOnly(12, 0)) });

        [Fact]
        public void Criar_SemMedicos_DeveLancarExcecao()
        {
            Action acao = () => Agenda.Criar(
                new List<MedicoAlocado>(),
                new[] { PacienteNaoAlocado.Criar("Ana", TimeSpan.FromMinutes(30), Prioridade.Alta) },
                DateTime.Today, TimeOnly.MinValue);

            acao.Should().Throw<DomainValidationException>()
                .WithMessage("*médicos*");
        }

        [Fact]
        public void Criar_SemSolicitacoes_DeveLancarExcecao()
        {
            Action acao = () => Agenda.Criar(
                new List<MedicoAlocado> { MedicoPadrao() },
                new List<PacienteNaoAlocado>(),
                DateTime.Today, TimeOnly.MinValue);

            acao.Should().Throw<DomainValidationException>()
                .WithMessage("*solicitações*");
        }

        [Fact]
        public void Criar_DeveAgendarEManterNaoAlocados()
        {
            var agenda = Agenda.Criar(
                new List<MedicoAlocado>
                {
                    MedicoAlocado.Criar("Dr. João", new List<Horario> { new(new TimeOnly(8, 0), new TimeOnly(8, 30)) })
                },
                new[]
                {
                    PacienteNaoAlocado.Criar("Ana", TimeSpan.FromMinutes(30), Prioridade.Alta),
                    PacienteNaoAlocado.Criar("Bia", TimeSpan.FromMinutes(30), Prioridade.Baixa)
                },
                DateTime.Today, TimeOnly.MinValue);

            agenda.Consultas.Should().ContainSingle().Which.PacienteNome.Should().Be("Ana");
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Bia");
        }

        [Fact]
        public void Encaixar_DeveMoverConsultaDeMenorPrioridadeParaNaoAlocados()
        {
            var agenda = Agenda.Criar(
                new List<MedicoAlocado>
                {
                    MedicoAlocado.Criar("Dr. João", new List<Horario> { new(new TimeOnly(8, 0), new TimeOnly(8, 30)) })
                },
                new[] { PacienteNaoAlocado.Criar("Baixa", TimeSpan.FromMinutes(30), Prioridade.Baixa) },
                DateTime.Today, TimeOnly.MinValue);

            agenda.Encaixar(PacienteNaoAlocado.Criar("Alta", TimeSpan.FromMinutes(30), Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().ContainSingle().Which.PacienteNome.Should().Be("Alta");
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Baixa");
            agenda.TemNaoAlocados.Should().BeTrue();
        }

        [Fact]
        public void Encaixar_DeveRealocarNaoAlocadosExistentesQuandoHaEspaco()
        {
            var agenda = Agenda.Criar(
                new List<MedicoAlocado>
                {
                    MedicoAlocado.Criar("Dr. João", new List<Horario> { new(new TimeOnly(8, 0), new TimeOnly(10, 0)) })
                },
                new[]
                {
                    PacienteNaoAlocado.Criar("Ana", TimeSpan.FromMinutes(120), Prioridade.Baixa),
                    PacienteNaoAlocado.Criar("Bia", TimeSpan.FromMinutes(15), Prioridade.Baixa)
                },
                DateTime.Today, TimeOnly.MinValue);

            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Ana");

            agenda.Encaixar(PacienteNaoAlocado.Criar("Carlos", TimeSpan.FromMinutes(30), Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Carlos");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Bia");
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Ana");
        }
    }
}
