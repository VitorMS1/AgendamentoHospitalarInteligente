using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;
using FluentAssertions;

namespace AgendamentoHospitalarInteligente.Tests.Domain.Entities
{
    public class MedicoAlocadoTests
    {
        private static Horario Hora(int hIni, int mIni, int hFim, int mFim)
        {
            return new(new TimeOnly(hIni, mIni), new TimeOnly(hFim, mFim));
        }

        [Fact]
        public void Criar_ComNomeEHorarios_DeveInstanciarMedico()
        {
            var medico = MedicoAlocado.Criar("Dr. João", new List<Horario> { Hora(8, 0, 12, 0) });

            medico.Nome.Should().Be("Dr. João");
            medico.HorariosDisponiveis.Should().HaveCount(1);
        }

        [Fact]
        public void Criar_SemHorarios_DeveLancarExcecao()
        {
            Action acao = () => MedicoAlocado.Criar("Dr. João", new List<Horario>());

            acao.Should().Throw<DomainValidationException>()
                .WithMessage("*pelo menos um horário*");
        }

        [Fact]
        public void Criar_ComHorariosSobrepostos_DeveLancarExcecao()
        {
            var horarios = new List<Horario> { Hora(8, 0, 10, 0), Hora(9, 0, 11, 0) };

            Action acao = () => MedicoAlocado.Criar("Dr. João", horarios);

            acao.Should().Throw<DomainValidationException>()
                .WithMessage("*conflita*");
        }

        [Fact]
        public void PrimeiroHorarioDisponivel_ComBlocoSuficiente_DeveRetornarSlotFatiado()
        {
            var medico = MedicoAlocado.Criar("Dr. João", new List<Horario> { Hora(8, 0, 12, 0) });

            var slot = medico.PrimeiroHorarioDisponivel(TimeSpan.FromMinutes(30), TimeOnly.MinValue);

            slot.Should().NotBeNull();
            slot!.Inicio.Should().Be(new TimeOnly(8, 0));
            slot.Fim.Should().Be(new TimeOnly(8, 30));
        }

        [Fact]
        public void PrimeiroHorarioDisponivel_ComBlocoInsuficiente_DeveRetornarNull()
        {
            var medico = MedicoAlocado.Criar("Dr. João", new List<Horario> { Hora(8, 0, 8, 20) });

            var slot = medico.PrimeiroHorarioDisponivel(TimeSpan.FromMinutes(30), TimeOnly.MinValue);

            slot.Should().BeNull();
        }

        [Fact]
        public void PrimeiroHorarioDisponivel_RespeitandoHoraAtual_DeveDescartarBlocosPassados()
        {
            var medico = MedicoAlocado.Criar("Dr. João",
                new List<Horario> { Hora(8, 0, 9, 0), Hora(10, 0, 12, 0) });

            var slot = medico.PrimeiroHorarioDisponivel(TimeSpan.FromMinutes(30), new TimeOnly(9, 30));

            slot!.Inicio.Should().Be(new TimeOnly(10, 0));
        }

        [Fact]
        public void AvancarHorario_DeveReduzirBlocoDisponivel()
        {
            var medico = MedicoAlocado.Criar("Dr. João", new List<Horario> { Hora(8, 0, 12, 0) });
            var slot = medico.PrimeiroHorarioDisponivel(TimeSpan.FromMinutes(30), TimeOnly.MinValue);

            medico.AvancarHorario(slot!);

            medico.HorariosDisponiveis.Should().ContainSingle()
                .Which.Inicio.Should().Be(new TimeOnly(8, 30));
        }

        [Fact]
        public void LiberarHorario_DeveFundirBlocosAdjacentes()
        {
            var medico = MedicoAlocado.Criar("Dr. João", new List<Horario> { Hora(8, 0, 12, 0) });
            var slot = medico.PrimeiroHorarioDisponivel(TimeSpan.FromMinutes(30), TimeOnly.MinValue);
            medico.AvancarHorario(slot!);

            medico.LiberarHorario(slot!);

            medico.HorariosDisponiveis.Should().ContainSingle()
                .Which.Should().BeEquivalentTo(Hora(8, 0, 12, 0));
        }
    }
}
