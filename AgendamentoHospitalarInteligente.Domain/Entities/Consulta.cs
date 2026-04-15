using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; private set; }
        public MedicoAlocado Medico { get; private set; }
        public string PacienteNome { get; private set; }
        public Prioridade Prioridade { get; private set; }
        public TimeSpan Duracao { get; private set; }
        public Horario Horario { get; private set; }

        private Consulta() { }

        public static Consulta Criar(MedicoAlocado medico, string pacienteNome, TimeSpan duracao, Prioridade prioridade, Horario horario)
        {
            var consulta = new Consulta();
            consulta.DefinirMedico(medico);
            consulta.DefinirPacienteNome(pacienteNome);
            consulta.DefinirDuracao(duracao);
            consulta.DefinirHorario(horario);
            consulta.Prioridade = prioridade;
            return consulta;
        }

        private void DefinirHorario(Horario horario)
        {
            DomainValidationException.When(horario == null, "O horário da consulta precisa ser informado");
            Horario = horario;
        }

        public void AtualizarHorario(Horario horario)
        {
            DomainValidationException.When(horario == null, "O horário da consulta precisa ser informado");
            Horario = horario!;
        }

        private void DefinirMedico(MedicoAlocado medico)
        {
            DomainValidationException.When(medico == null, "O médico precisa ser informado");
            Medico = medico;
        }

        private void DefinirPacienteNome(string pacienteNome)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(pacienteNome), "O nome do paciente é obrigatório.");
            DomainValidationException.When(pacienteNome.Length > 100, "O nome do paciente não pode exceder 100 caracteres.");
            PacienteNome = pacienteNome;
        }

        private void DefinirDuracao(TimeSpan duracao)
        {
            DomainValidationException.When(duracao <= TimeSpan.Zero, "A duração da consulta deve ser positiva");
            Duracao = duracao;
        }
    }
}
