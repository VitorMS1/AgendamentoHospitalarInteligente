using AgendamentoHospitalarInteligente.Domain.Enums;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using AgendamentoHospitalarInteligente.Domain.ValueObjects;

namespace AgendamentoHospitalarInteligente.Domain.Entities
{
    public class Agenda
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }

        private readonly List<MedicoAlocado> _medicos = new();
        private readonly List<Consulta> _consultas = new();
        private readonly List<PacienteNaoAlocado> _pacientesNaoAlocados = new();

        public IReadOnlyCollection<MedicoAlocado> Medicos => _medicos.AsReadOnly();
        public IReadOnlyCollection<Consulta> Consultas => _consultas.AsReadOnly();
        public IReadOnlyCollection<PacienteNaoAlocado> PacientesNaoAlocados => _pacientesNaoAlocados.AsReadOnly();
        public bool TemNaoAlocados => _pacientesNaoAlocados.Any();

        private Agenda() { }

        /// <summary>
        /// Cria uma nova Agenda, alocando as solicitações nos médicos disponíveis.
        /// </summary>
        public static Agenda Criar(IEnumerable<MedicoAlocado> medicos, IEnumerable<PacienteNaoAlocado> solicitacoes, DateTime dataReferencia, TimeOnly agora)
        {
            var agenda = new Agenda();
            agenda.Data = dataReferencia;
            agenda.DefinirMedicos(medicos!);
            agenda.AlocarPacientes(solicitacoes!, agora);
            return agenda;
        }

        private void DefinirMedicos(IEnumerable<MedicoAlocado> medicos)
        {
            DomainValidationException.When(medicos == null || !medicos.Any(), "A lista de médicos não pode ser vazia ou nula.");
            _medicos.AddRange(medicos!);
        }

        /// <summary>
        /// Aloca uma lista de pacientes nos médicos disponíveis, buscando o melhor horário para cada um.
        /// Ordena por prioridade (desc) e duração (asc). Quem não couber vai para não alocados.
        /// </summary>
        public void AlocarPacientes(IEnumerable<PacienteNaoAlocado> solicitacoes, TimeOnly agora)
        {
            DomainValidationException.When(solicitacoes == null || !solicitacoes.Any(), "A lista de solicitações não pode ser vazia ou nula.");

            var ordenados = solicitacoes!
                .OrderByDescending(s => s.Prioridade)
                .ThenBy(s => s.Duracao)
                .ToList();

            _pacientesNaoAlocados.Clear();

            foreach (var item in ordenados)
            {
                MedicoAlocado? melhorMedico = null;
                Horario? melhorHorario = null;

                foreach (var medico in _medicos)
                {
                    var horario = medico.PrimeiroHorarioDisponivel(item.Duracao, agora);
                    if (horario is not null && (melhorHorario is null || horario.Inicio < melhorHorario.Inicio))
                    {
                        melhorMedico = medico;
                        melhorHorario = horario;
                    }
                }

                if (melhorMedico is not null)
                {
                    var consulta = Consulta.Criar(melhorMedico, item.Nome, item.Duracao, item.Prioridade, melhorHorario!);
                    melhorMedico.AvancarHorario(melhorHorario!);
                    _consultas.Add(consulta);
                }
                else
                {
                    _pacientesNaoAlocados.Add(item);
                }
            }
        }

        /// <summary>
        /// Encaixa uma nova solicitação na agenda, reorganizando consultas.
        /// </summary>
        public void Encaixar(PacienteNaoAlocado solicitacao, TimeOnly agora)
        {
            DomainValidationException.When(solicitacao == null, "A solicitação não pode ser nula.");
            DomainValidationException.When(_consultas.Any(c => c.PacienteNome.Equals(solicitacao!.Nome, StringComparison.OrdinalIgnoreCase)), "O paciente já possui uma consulta agendada.");

            var indiceInsercao = EncontrarIndiceInsercao(solicitacao!.Prioridade, solicitacao.Duracao);

            var candidatas = _consultas.Skip(indiceInsercao).ToList();
            var consultasRemovidas = candidatas.Where(c => c.Horario.Inicio >= agora).ToList();

            foreach (var consulta in consultasRemovidas)
            {
                _consultas.Remove(consulta);
                consulta.Medico.LiberarHorario(consulta.Horario);
            }

            _pacientesNaoAlocados.Add(solicitacao);

            foreach (var consulta in consultasRemovidas)
                _pacientesNaoAlocados.Add(PacienteNaoAlocado.Criar(consulta.PacienteNome, consulta.Duracao, consulta.Prioridade));

            AlocarPacientes(_pacientesNaoAlocados, agora);
        }

        private int EncontrarIndiceInsercao(Prioridade prioridade, TimeSpan duracao)
        {
            for (var i = 0; i < _consultas.Count; i++)
            {
                var existente = _consultas[i];

                if (prioridade > existente.Prioridade)
                    return i;

                if (prioridade == existente.Prioridade && duracao < existente.Duracao)
                    return i;
            }

            return _consultas.Count;
        }
    }
}
