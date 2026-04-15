namespace AgendamentoHospitalarInteligente.Desktop.Models
{
    public class MedicoAlocadoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<HorarioDto> HorariosDisponiveis { get; set; } = new();
    }
}
