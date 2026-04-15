using AgendamentoHospitalarInteligente.Application.DTOs;
using AgendamentoHospitalarInteligente.Application.DTOs.Agendas;
using AgendamentoHospitalarInteligente.Application.DTOs.MedicosModelo;
using AgendamentoHospitalarInteligente.Domain.Entities;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Application.Mappings
{
    public static class DomainToDtoMapper
    {
        public static MedicoModeloResponse ToResponse(this MedicoModelo medicoModelo)
        {
            return new()
            {
                Id = medicoModelo.Id,
                Nome = medicoModelo.Nome,
                HorariosDisponiveis = medicoModelo.HorariosDisponiveis.Select(h => h.ToDto()).ToList()
            };
        }

        public static HorarioDto ToDto(this Horario horario)
        {
            return new()
            {
                Inicio = horario.Inicio.ToString("HH:mm"),
                Fim = horario.Fim.ToString("HH:mm")
            };
        }

        public static ConsultaResponse ToResponse(this Consulta consulta)
        {
            return new()
            {
                Id = consulta.Id,
                MedicoId = consulta.Medico.Id,
                MedicoNome = consulta.Medico.Nome,
                PacienteNome = consulta.PacienteNome,
                Prioridade = consulta.Prioridade,
                DuracaoMinutos = (int)consulta.Duracao.TotalMinutes,
                HorarioInicio = consulta.Horario.Inicio.ToString("HH:mm"),
                HorarioFim = consulta.Horario.Fim.ToString("HH:mm")
            };
        }

        public static MedicoAlocadoResponse ToResponse(this MedicoAlocado medicoAlocado)
        {
            return new()
            {
                Id = medicoAlocado.Id,
                Nome = medicoAlocado.Nome,
                HorariosDisponiveis = medicoAlocado.HorariosDisponiveis.Select(h => h.ToDto()).ToList()
            };
        }

        public static PacienteNaoAlocadoResponse ToResponse(this PacienteNaoAlocado paciente)
        {
            return new()
            {
                Nome = paciente.Nome,
                DuracaoMinutos = (int)paciente.Duracao.TotalMinutes,
                Prioridade = paciente.Prioridade
            };
        }

        public static AgendaResponse ToResponse(this Agenda agenda)
        {
            return new()
            {
                Id = agenda.Id,
                Data = agenda.Data,
                Medicos = agenda.Medicos.Select(m => m.ToResponse()).ToList(),
                Consultas = agenda.Consultas.Select(c => c.ToResponse()).ToList(),
                PacientesNaoAlocados = agenda.PacientesNaoAlocados.Select(p => p.ToResponse()).ToList()
            };
        }
    }
}
