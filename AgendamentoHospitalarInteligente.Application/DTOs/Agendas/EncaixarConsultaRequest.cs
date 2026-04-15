using AgendamentoHospitalarInteligente.Domain.Enums;

namespace AgendamentoHospitalarInteligente.Application.DTOs.Agendas
{
    public class EncaixarConsultaRequest
    {
        public string PacienteNome { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }
        public Prioridade Prioridade { get; set; }
        public string? HoraAtual { get; set; }
    }
}
