import { useEffect, useMemo, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { api } from '../services/api';
import type { AgendaResponse, Prioridade } from '../types';
import PrioridadeTag from '../components/PrioridadeTag';

const PRIORIDADES: Prioridade[] = ['Baixa', 'Media', 'Alta'];

export default function AgendaDetalhesPage() {
  const { id } = useParams<{ id: string }>();
  const agendaId = Number(id);
  const [agenda, setAgenda] = useState<AgendaResponse | null>(null);
  const [erro, setErro] = useState<string | null>(null);
  const [mensagem, setMensagem] = useState<string | null>(null);

  const [encaixeAberto, setEncaixeAberto] = useState(false);
  const [pacienteNome, setPacienteNome] = useState('');
  const [duracao, setDuracao] = useState(30);
  const [prioridade, setPrioridade] = useState<Prioridade>('Baixa');
  const [respeitarHoraAtual, setRespeitarHoraAtual] = useState(false);

  async function carregar() {
    try {
      const res = await api.obterAgenda(agendaId);
      setAgenda(res);
      setErro(null);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  useEffect(() => { carregar(); }, [agendaId]);

  const consultasOrdenadas = useMemo(() => {
    if (!agenda) return [];
    return [...agenda.consultas].sort((a, b) => a.horarioInicio.localeCompare(b.horarioInicio));
  }, [agenda]);

  async function encaixar() {
    try {
      if (!pacienteNome) {
        setErro('Informe o nome do paciente.');
        return;
      }
      const horaAtual = respeitarHoraAtual ? new Date().toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit', hour12: false }) : null;
      const res = await api.encaixar(agendaId, {
        pacienteNome,
        duracaoMinutos: duracao,
        prioridade,
        horaAtual
      });
      setAgenda(res);
      setPacienteNome('');
      setEncaixeAberto(false);
      setMensagem('Consulta encaixada com sucesso!');
      setErro(null);
      setTimeout(() => setMensagem(null), 3000);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  if (!agenda) {
    return (
      <div>
        <Link to="/agendas">&larr; Voltar</Link>
        {erro && <div className="alert error" style={{ marginTop: 12 }}>{erro}</div>}
      </div>
    );
  }

  return (
    <div>
      <div className="header-bar">
        <div>
          <Link to="/agendas">&larr; Voltar</Link>
          <h2>Detalhes da Agenda #{agenda.id}</h2>
        </div>
        <button onClick={() => setEncaixeAberto(!encaixeAberto)}>
          {encaixeAberto ? 'Cancelar Encaixe' : '+ Adicionar Encaixe'}
        </button>
      </div>

      {erro && <div className="alert error">{erro}</div>}
      {mensagem && <div className="alert success">{mensagem}</div>}

      {encaixeAberto && (
        <div className="card">
          <h3>Encaixar Consulta</h3>
          <div className="form-row">
            <div style={{ flex: 2 }}>
              <label>Paciente</label>
              <input value={pacienteNome} onChange={e => setPacienteNome(e.target.value)} style={{ width: '100%' }} />
            </div>
            <div>
              <label>Duração (min)</label>
              <input type="number" min={5} max={480} value={duracao} onChange={e => setDuracao(Number(e.target.value))} />
            </div>
            <div>
              <label>Prioridade</label>
              <select value={prioridade} onChange={e => setPrioridade(e.target.value as Prioridade)}>
                {PRIORIDADES.map(p => <option key={p} value={p}>{p}</option>)}
              </select>
            </div>
            <div style={{ display: 'flex', alignItems: 'flex-end' }}>
              <button onClick={encaixar}>Encaixar</button>
            </div>
          </div>
          <label style={{ display: 'flex', alignItems: 'center', gap: 8, cursor: 'pointer', margin: 0 }}>
            <input
              type="checkbox"
              checked={respeitarHoraAtual}
              onChange={e => setRespeitarHoraAtual(e.target.checked)}
            />
            Respeitar hora atual (só considera horários futuros)
          </label>
        </div>
      )}

      <div className="card">
        <h3>Médicos da Agenda</h3>
        <table className="table">
          <thead>
            <tr><th>Médico</th><th>Horários Restantes</th></tr>
          </thead>
          <tbody>
            {agenda.medicos.map(m => (
              <tr key={m.id}>
                <td>{m.nome}</td>
                <td>
                  {m.horariosDisponiveis.length > 0
                    ? m.horariosDisponiveis.map(h => `${h.inicio}-${h.fim}`).join(', ')
                    : <span className="muted">(sem horários restantes)</span>}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="card">
        <h3>Consultas Agendadas ({consultasOrdenadas.length})</h3>
        <table className="table">
          <thead>
            <tr>
              <th>Horário</th>
              <th>Paciente</th>
              <th>Médico</th>
              <th>Prioridade</th>
              <th>Duração</th>
            </tr>
          </thead>
          <tbody>
            {consultasOrdenadas.map(c => (
              <tr key={c.id}>
                <td>{c.horarioInicio} - {c.horarioFim}</td>
                <td>{c.pacienteNome}</td>
                <td>{c.medicoNome}</td>
                <td><PrioridadeTag value={c.prioridade} /></td>
                <td>{c.duracaoMinutos} min</td>
              </tr>
            ))}
            {consultasOrdenadas.length === 0 && (
              <tr><td colSpan={5} className="muted">Nenhuma consulta agendada.</td></tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="card">
        <h3>Não Alocados ({agenda.pacientesNaoAlocados.length})</h3>
        <table className="table">
          <thead>
            <tr><th>Paciente</th><th>Duração</th><th>Prioridade</th></tr>
          </thead>
          <tbody>
            {agenda.pacientesNaoAlocados.map((p, i) => (
              <tr key={i}>
                <td>{p.nome}</td>
                <td>{p.duracaoMinutos} min</td>
                <td><PrioridadeTag value={p.prioridade} /></td>
              </tr>
            ))}
            {agenda.pacientesNaoAlocados.length === 0 && (
              <tr><td colSpan={3} className="muted">Todos os pacientes foram alocados.</td></tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
