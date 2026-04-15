using AgendamentoHospitalarInteligente.Domain.Enums;

namespace AgendamentoHospitalarInteligente.Application.DTOs.Agendas
{
    public class ConsultaResponse
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string MedicoNome { get; set; } = string.Empty;
        public string PacienteNome { get; set; } = string.Empty;
        public Prioridade Prioridade { get; set; }
        public int DuracaoMinutos { get; set; }
        public string HorarioInicio { get; set; } = string.Empty;
        public string HorarioFim { get; set; } = string.Empty;
    }
}
