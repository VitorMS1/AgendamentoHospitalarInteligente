using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Domain.Entities
{
    public class MedicoModelo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        private readonly List<Horario> _horariosDisponiveis = new();

        public IReadOnlyCollection<Horario> HorariosDisponiveis => _horariosDisponiveis.AsReadOnly();

        private MedicoModelo() { }

        public static MedicoModelo Criar(string nome, List<Horario> horariosDisponiveis)
        {
            var medicoModelo = new MedicoModelo();
            medicoModelo.DefinirNome(nome);
            medicoModelo.DefinirHorariosDisponiveis(horariosDisponiveis);
            return medicoModelo;
        }

        public void Atualizar(string nome, List<Horario> horarios)
        {
            DefinirNome(nome);
            _horariosDisponiveis.Clear();
            DefinirHorariosDisponiveis(horarios);
        }

        private void DefinirNome(string nome)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "O nome do médico modelo é obrigatório.");
            DomainValidationException.When(nome.Length > 100, "O nome do médico modelo não pode exceder 100 caracteres.");
            Nome = nome;
        }

        private void DefinirHorariosDisponiveis(List<Horario> horarios)
        {
            DomainValidationException.When(horarios == null || !horarios.Any(), "O médico modelo deve ter pelo menos um horário disponível.");

            foreach (var horario in horarios!.OrderBy(h => h.Inicio))
            {
                DomainValidationException.When(_horariosDisponiveis.Any(h => h.Inicio < horario.Fim && h.Fim > horario.Inicio), $"O horário {horario.Inicio}-{horario.Fim} conflita com um horário existente");
                _horariosDisponiveis.Add(horario);
            }
        }
    }
}
