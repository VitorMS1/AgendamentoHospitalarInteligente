using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Domain.Entities
{
    public class MedicoAlocado
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        private readonly List<Horario> _horariosDisponiveis = new();

        public IReadOnlyCollection<Horario> HorariosDisponiveis =>
            _horariosDisponiveis.OrderBy(h => h.Inicio).ToList().AsReadOnly();

        private MedicoAlocado() { }

        public static MedicoAlocado Criar(string nome, List<Horario> horariosDisponiveis)
        {
            var agendaMedico = new MedicoAlocado();
            agendaMedico.DefinirNome(nome);
            agendaMedico.DefinirHorariosDisponiveis(horariosDisponiveis);
            return agendaMedico;
        }

        private void DefinirNome(string nome)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "O nome do médico é obrigatório.");
            DomainValidationException.When(nome.Length > 100, "O nome do médico não pode exceder 100 caracteres.");
            Nome = nome;
        }

        private void DefinirHorariosDisponiveis(List<Horario> horarios)
        {
            DomainValidationException.When(horarios == null || !horarios.Any(), "O médico deve ter pelo menos um horário disponível.");

            foreach (var horario in horarios!.OrderBy(h => h.Inicio))
            {
                DomainValidationException.When(horario.Inicio >= horario.Fim, "O horário de início deve ser anterior ao fim.");
                DomainValidationException.When(_horariosDisponiveis.Any(h => h.Inicio < horario.Fim && h.Fim > horario.Inicio), $"O horário {horario.Inicio}-{horario.Fim} conflita com um horário existente");
                _horariosDisponiveis.Add(horario);
            }
        }

        public Horario? PrimeiroHorarioDisponivel(TimeSpan duracao, TimeOnly agora)
        {
            foreach (var bloco in _horariosDisponiveis.OrderBy(h => h.Inicio))
            {
                if (bloco.Fim <= agora) continue;

                var inicio = bloco.Inicio < agora ? agora : bloco.Inicio;
                var fim = inicio.Add(duracao);

                if (fim <= inicio || bloco.Fim < fim) continue;

                return new Horario(inicio, fim);
            }

            return null;
        }

        public void AvancarHorario(Horario horarioOcupado)
        {
            var bloco = _horariosDisponiveis.FirstOrDefault(h => h.Contem(horarioOcupado));

            DomainValidationException.When(bloco == null, "Horário da consulta não pertence a nenhum bloco disponível.");

            _horariosDisponiveis.Remove(bloco!);

            if (bloco!.Inicio < horarioOcupado.Inicio)
                _horariosDisponiveis.Add(new Horario(bloco.Inicio, horarioOcupado.Inicio));

            if (horarioOcupado.Fim < bloco.Fim)
                _horariosDisponiveis.Add(new Horario(horarioOcupado.Fim, bloco.Fim));
        }

        public void LiberarHorario(Horario horario)
        {
            DomainValidationException.When(horario == null, "Horário inválido.");

            var inicio = horario!.Inicio;
            var fim = horario.Fim;

            var anterior = _horariosDisponiveis.FirstOrDefault(h => h.Fim == inicio);
            if (anterior != null)
            {
                inicio = anterior.Inicio;
                _horariosDisponiveis.Remove(anterior);
            }

            var posterior = _horariosDisponiveis.FirstOrDefault(h => h.Inicio == fim);
            if (posterior != null)
            {
                fim = posterior.Fim;
                _horariosDisponiveis.Remove(posterior);
            }

            _horariosDisponiveis.Add(new Horario(inicio, fim));
        }
    }
}
