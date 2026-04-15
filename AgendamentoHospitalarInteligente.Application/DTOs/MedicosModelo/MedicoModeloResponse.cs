namespace AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo
{
    public class MedicoModeloResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<HorarioDto> HorariosDisponiveis { get; set; } = new();
    }
}
