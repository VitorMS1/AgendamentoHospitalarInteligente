using AgendamentoHospitalarInteligente.Domain.Exceptions;

namespace AgendamentoHospitalarInteligente.Domain.ValueObjects
{
    public record Horario
    {
        public TimeOnly Inicio { get; init; }
        public TimeOnly Fim { get; init; }

        private Horario() { }

        public Horario(TimeOnly inicio, TimeOnly fim)
        {
            DomainValidationException.When(fim <= inicio, "Fim deve ser posterior ao início.");

            Inicio = inicio;
            Fim = fim;
        }

        public static Horario CriarDeString(string inicio, string fim)
        {
            return new Horario(TimeOnly.ParseExact(inicio.Trim(), "HH:mm"), TimeOnly.ParseExact(fim.Trim(), "HH:mm"));
        }

        public bool Contem(Horario outro)
        {
            return Inicio <= outro.Inicio && Fim >= outro.Fim;
        }
    }
}
