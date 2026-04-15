using AgendamentoHospitalarInteligente.Domain.Enums;

namespace AgendamentoHospitalarInteligente.Application.DTOs.Agendas
{
    public class PacienteNaoAlocadoResponse
    {
        public string Nome { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
