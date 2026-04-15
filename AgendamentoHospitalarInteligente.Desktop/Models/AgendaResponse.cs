namespace AgendamentoHospitalarInteligente.Desktop.Models
{
    public class AgendaResponse
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<MedicoAlocadoResponse> Medicos { get; set; } = new();
        public List<ConsultaResponse> Consultas { get; set; } = new();
        public List<PacienteNaoAlocadoResponse> PacientesNaoAlocados { get; set; } = new();
    }
}
