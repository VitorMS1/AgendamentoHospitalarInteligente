using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Application.Mappings
{
    public static class DtoToDomainMapper
    {
        public static MedicoAlocado ToDomain(this MedicoAgendaDto dto)
        {
            var horarios = dto.HorariosDisponiveis.Select(h => Horario.CriarDeString(h.Inicio, h.Fim)).ToList();
            return MedicoAlocado.Criar(dto.Nome, horarios);
        }

        public static PacienteNaoAlocado ToDomain(this SolicitacaoDto dto)
        {
            return PacienteNaoAlocado.Criar(dto.PacienteNome, TimeSpan.FromMinutes(dto.DuracaoMinutos), dto.Prioridade);
        }

        public static List<MedicoAlocado> ToDomain(this List<MedicoAgendaDto> dtos)
        {
            return dtos.Select(d => d.ToDomain()).ToList();
        }

        public static List<PacienteNaoAlocado> ToDomain(this List<SolicitacaoDto> dtos)
        {
            return dtos.Select(d => d.ToDomain()).ToList();
        }
    }
}
