using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Domain.Entities
{
    public class AgendaAlocacaoTests
    {
        private static MedicoAlocado Medico(string nome, params (int hIni, int mIni, int hFim, int mFim)[] blocos)
        {
            return MedicoAlocado.Criar(nome, blocos
                .Select(b => new Horario(new TimeOnly(b.hIni, b.mIni), new TimeOnly(b.hFim, b.mFim)))
                .ToList());
        }

        private static PacienteNaoAlocado Solicitar(string pacienteNome, int duracaoMin, Prioridade prioridade)
        {
            return PacienteNaoAlocado.Criar(pacienteNome, TimeSpan.FromMinutes(duracaoMin), prioridade);
        }

        private static Agenda CriarAgenda(MedicoAlocado[] medicos, PacienteNaoAlocado[] solicitacoes, TimeOnly? agora = null)
        {
            return Agenda.Criar(medicos, solicitacoes, DateTime.Today, agora ?? TimeOnly.MinValue);
        }

        [Fact]
        public void Criar_ComUmMedicoEUmaSolicitacao_DeveAgendarCorretamente()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 12, 0)) },
                new[] { Solicitar("Ana", 30, Prioridade.Alta) });

            agenda.Consultas.Should().ContainSingle();
            var consulta = agenda.Consultas.Single();
            consulta.PacienteNome.Should().Be("Ana");
            consulta.Horario.Inicio.Should().Be(new TimeOnly(8, 0));
            consulta.Horario.Fim.Should().Be(new TimeOnly(8, 30));
            agenda.PacientesNaoAlocados.Should().BeEmpty();
        }

        [Fact]
        public void Criar_ComDemandaMaiorQueCapacidade_DeveDeixarPacientesNaoAlocados()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 9, 0)) },
                new[]
                {
                    Solicitar("Ana",  30, Prioridade.Alta),
                    Solicitar("Bia",  30, Prioridade.Alta),
                    Solicitar("Caio", 30, Prioridade.Alta)
                });

            agenda.Consultas.Should().HaveCount(2);
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Caio");
        }

        [Fact]
        public void Criar_DeveRespeitarOrdemDePrioridade()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 9, 0)) },
                new[]
                {
                    Solicitar("Baixa", 30, Prioridade.Baixa),
                    Solicitar("Alta",  30, Prioridade.Alta)
                });

            agenda.Consultas.Should().HaveCount(2);
            agenda.Consultas.OrderBy(c => c.Horario.Inicio).First().PacienteNome.Should().Be("Alta");
        }

        [Fact]
        public void Criar_QuandoConsultasSeSeguem_DeveAlocarSemConflitoDeHorario()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 9, 30)) },
                new[]
                {
                    Solicitar("Ana", 30, Prioridade.Alta),
                    Solicitar("Bia", 30, Prioridade.Alta),
                    Solicitar("Caio", 30, Prioridade.Alta)
                });

            agenda.Consultas.Should().HaveCount(3);
            var consultasEmOrdem = agenda.Consultas.OrderBy(c => c.Horario.Inicio).ToList();

            for (var i = 1; i < consultasEmOrdem.Count; i++)
                consultasEmOrdem[i].Horario.Inicio.Should().BeOnOrAfter(consultasEmOrdem[i - 1].Horario.Fim);
        }

        [Fact]
        public void Criar_ComHoraAtual_DeveIgnorarBlocosPassados()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 9, 0), (14, 0, 18, 0)) },
                new[] { Solicitar("Ana", 30, Prioridade.Alta) },
                new TimeOnly(13, 0));

            agenda.Consultas.Single().Horario.Inicio.Should().Be(new TimeOnly(14, 0));
        }

        [Fact]
        public void Criar_DevePriorizarMedicoComSlotMaisCedo_NaoComBlocoMaisCedo()
        {
            var agenda = CriarAgenda(
                new[]
                {
                    Medico("Medico01", (13, 30, 14, 0), (16, 0, 18, 0)),
                    Medico("Medico02", (15, 0, 18, 0))
                },
                new[] { Solicitar("Ana", 60, Prioridade.Alta) });

            var consulta = agenda.Consultas.Single();
            consulta.Medico.Nome.Should().Be("Medico02");
            consulta.Horario.Inicio.Should().Be(new TimeOnly(15, 0));
            consulta.Horario.Fim.Should().Be(new TimeOnly(16, 0));
        }

        [Fact]
        public void Criar_DeveRegistrarDataInformada()
        {
            var data = new DateTime(2025, 6, 15, 10, 30, 0);
            var agenda = Agenda.Criar(
                new[] { Medico("Dr. João", (8, 0, 12, 0)) },
                new[] { Solicitar("Ana", 30, Prioridade.Alta) },
                data, TimeOnly.MinValue);

            agenda.Data.Should().Be(data);
        }

        [Fact]
        public void Encaixar_QuandoHaHorarioLivre_DeveAdicionarConsulta()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 10, 0)) },
                new[] { Solicitar("Ana", 30, Prioridade.Alta) });

            agenda.Encaixar(Solicitar("Bia", 30, Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().HaveCount(2);
            agenda.PacientesNaoAlocados.Should().BeEmpty();
        }

        [Fact]
        public void Encaixar_ComMaiorPrioridade_DevePreemptarConsultaDeMenorPrioridade()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 8, 30)) },
                new[] { Solicitar("Baixa", 30, Prioridade.Baixa) });

            agenda.Encaixar(Solicitar("Alta", 30, Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().ContainSingle().Which.PacienteNome.Should().Be("Alta");
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Baixa");
        }

        [Fact]
        public void Encaixar_SemEspacoEMesmaPrioridade_DeveMarcarPacienteComoNaoAlocado()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 8, 30)) },
                new[] { Solicitar("Ana", 30, Prioridade.Alta) });

            agenda.Encaixar(Solicitar("Bia", 30, Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().ContainSingle().Which.PacienteNome.Should().Be("Ana");
            agenda.PacientesNaoAlocados.Should().ContainSingle().Which.Nome.Should().Be("Bia");
        }

        [Fact]
        public void Encaixar_DeveReorganizarConsultasPosteriores()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (8, 0, 10, 0)) },
                new[]
                {
                    Solicitar("Ana",  30, Prioridade.Media),
                    Solicitar("Bia",  30, Prioridade.Media),
                    Solicitar("Caio", 30, Prioridade.Media)
                });

            agenda.Encaixar(Solicitar("Alta", 5, Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().HaveCount(4);
            var consultas = agenda.Consultas.OrderBy(c => c.Horario.Inicio).ToList();

            consultas[0].PacienteNome.Should().Be("Alta");
            consultas[0].Horario.Inicio.Should().Be(new TimeOnly(8, 0));
            consultas[0].Horario.Fim.Should().Be(new TimeOnly(8, 5));
            consultas[1].Horario.Inicio.Should().Be(new TimeOnly(8, 5));
        }

        [Fact]
        public void Encaixar_ComEspacoResidualAposLiberacao_DeveEncaixarCorretamente()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (14, 0, 15, 30)) },
                new[]
                {
                    Solicitar("Alta1", 30, Prioridade.Alta),
                    Solicitar("Alta2", 30, Prioridade.Alta),
                    Solicitar("Baixa", 15, Prioridade.Baixa)
                });

            agenda.Encaixar(Solicitar("Media", 30, Prioridade.Media), TimeOnly.MinValue);

            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Media");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Alta1");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Alta2");
        }

        [Fact]
        public void Encaixar_ComPreempcao_NaoDeveRemoverConsultasSemNecessidade()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (14, 30, 17, 0)) },
                new[]
                {
                    Solicitar("Alta1", 30, Prioridade.Alta),
                    Solicitar("Alta2", 30, Prioridade.Alta),
                    Solicitar("Media1", 30, Prioridade.Media),
                    Solicitar("Media2", 60, Prioridade.Media)
                });

            agenda.Encaixar(Solicitar("EncaixeAlta", 75, Prioridade.Alta), TimeOnly.MinValue);

            agenda.Consultas.Should().Contain(c => c.PacienteNome == "EncaixeAlta");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Alta1");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Alta2");
        }

        [Fact]
        public void Encaixar_RespeitandoHoraAtual_NaoDeveReorganizarConsultasPassadas()
        {
            var agenda = CriarAgenda(
                new[] { Medico("Dr. João", (14, 0, 15, 30)) },
                new[]
                {
                    Solicitar("Baixa1", 30, Prioridade.Baixa),
                    Solicitar("Baixa2", 30, Prioridade.Baixa),
                    Solicitar("Baixa3", 30, Prioridade.Baixa)
                });

            agenda.Encaixar(Solicitar("Alta", 30, Prioridade.Alta), new TimeOnly(15, 0));

            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Baixa1");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Baixa2");
            agenda.Consultas.Should().Contain(c => c.PacienteNome == "Alta");
            agenda.PacientesNaoAlocados.Should().Contain(p => p.Nome == "Baixa3");
        }
    }
}
