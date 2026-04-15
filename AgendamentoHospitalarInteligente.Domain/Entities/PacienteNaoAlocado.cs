using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.Exceptions;

namespace AgendamentoHospitalarInteligente.Domain.Entities
{
    public class PacienteNaoAlocado
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public TimeSpan Duracao { get; private set; }
        public Prioridade Prioridade { get; private set; }

        private PacienteNaoAlocado() { }

        public static PacienteNaoAlocado Criar(string nome, TimeSpan duracao, Prioridade prioridade)
        {
            var paciente = new PacienteNaoAlocado();
            paciente.DefinirNome(nome);
            paciente.DefinirDuracao(duracao);
            paciente.Prioridade = prioridade;
            return paciente;
        }

        private void DefinirNome(string nome)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(nome), "O nome do paciente é obrigatório.");
            DomainValidationException.When(nome.Length > 100, "O nome do paciente não pode exceder 100 caracteres.");
            Nome = nome;
        }

        private void DefinirDuracao(TimeSpan duracao)
        {
            DomainValidationException.When(duracao <= TimeSpan.Zero, "A duração deve ser positiva.");
            Duracao = duracao;
        }
    }
}
