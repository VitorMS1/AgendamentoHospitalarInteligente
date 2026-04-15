namespace AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo
{
    public class AtualizarMedicoModeloRequest
    {
        public string Nome { get; set; } = string.Empty;
        public List<HorarioDto> HorariosDisponiveis { get; set; } = new();
    }
}
