using AgendamentoHospitalarInteligente.Desktop.Models.Enums;

namespace AgendamentoHospitalarInteligente.Desktop.Models
{
    public class PacienteNaoAlocadoResponse
    {
        public string Nome { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
