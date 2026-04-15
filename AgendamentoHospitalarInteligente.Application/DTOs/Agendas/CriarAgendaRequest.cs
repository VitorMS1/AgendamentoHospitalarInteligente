using AgendamentoHospitalarInteligente.Domain.Enums;

namespace AgendamentoHospitalarInteligente.Application.DTOs.Agendas
{
    public class CriarAgendaRequest
    {
        public List<MedicoAgendaDto> Medicos { get; set; } = new();
        public List<SolicitacaoDto> Solicitacoes { get; set; } = new();
        public string? HoraAtual { get; set; }
    }

    public class MedicoAgendaDto
    {
        public string Nome { get; set; } = string.Empty;
        public List<HorarioDto> HorariosDisponiveis { get; set; } = new();
    }

    public class SolicitacaoDto
    {
        public string PacienteNome { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
