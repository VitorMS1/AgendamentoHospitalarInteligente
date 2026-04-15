import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { api } from '../services/api';
import type {
  HorarioDto,
  MedicoAgendaDto,
  MedicoModeloResponse,
  Prioridade,
  SolicitacaoDto
} from '../types';
import AutocompleteMedico from '../components/AutocompleteMedico';

const PRIORIDADES: Prioridade[] = ['Baixa', 'Media', 'Alta'];

export default function CriarAgendaPage() {
  const navigate = useNavigate();
  const [medicosAdicionados, setMedicosAdicionados] = useState<MedicoAgendaDto[]>([]);
  const [solicitacoes, setSolicitacoes] = useState<SolicitacaoDto[]>([]);
  const [erro, setErro] = useState<string | null>(null);
  const [gerando, setGerando] = useState(false);
  const [respeitarHoraAtual, setRespeitarHoraAtual] = useState(false);

  // Formulário médico
  const [nomeMedico, setNomeMedico] = useState('');
  const [inicioTmp, setInicioTmp] = useState('');
  const [fimTmp, setFimTmp] = useState('');
  const [horariosTmp, setHorariosTmp] = useState<HorarioDto[]>([]);

  // Formulário solicitação
  const [pacienteNome, setPacienteNome] = useState('');
  const [duracao, setDuracao] = useState(30);
  const [prioridade, setPrioridade] = useState<Prioridade>('Baixa');

  function aplicarModelo(medico: MedicoModeloResponse) {
    setNomeMedico(medico.nome);
    setHorariosTmp([...medico.horariosDisponiveis]);
  }

  function adicionarHorarioTmp() {
    if (!inicioTmp || !fimTmp) return;
    setHorariosTmp([...horariosTmp, { inicio: inicioTmp, fim: fimTmp }]);
    setInicioTmp('');
    setFimTmp('');
  }

  function adicionarMedico() {
    if (!nomeMedico || horariosTmp.length === 0) {
      setErro('Informe o nome e pelo menos um horário.');
      return;
    }
    setMedicosAdicionados([...medicosAdicionados, { nome: nomeMedico, horariosDisponiveis: horariosTmp }]);
    setNomeMedico('');
    setHorariosTmp([]);
    setModeloSelecionado('');
    setErro(null);
  }

  function removerMedico(idx: number) {
    setMedicosAdicionados(medicosAdicionados.filter((_, i) => i !== idx));
  }

  function adicionarSolicitacao() {
    if (!pacienteNome) {
      setErro('Informe o nome do paciente.');
      return;
    }
    setSolicitacoes([...solicitacoes, { pacienteNome, duracaoMinutos: duracao, prioridade }]);
    setPacienteNome('');
    setErro(null);
  }

  function removerSolicitacao(idx: number) {
    setSolicitacoes(solicitacoes.filter((_, i) => i !== idx));
  }

  async function gerarAgenda() {
    try {
      setGerando(true);
      const horaAtual = respeitarHoraAtual ? new Date().toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit', hour12: false }) : null;
      const agenda = await api.criarAgenda({
        medicos: medicosAdicionados,
        solicitacoes,
        horaAtual
      });
      navigate(`/agendas/${agenda.id}`);
    } catch (e) {
      setErro((e as Error).message);
      setGerando(false);
    }
  }

  const podeGerar = medicosAdicionados.length > 0 && solicitacoes.length > 0 && !gerando;

  return (
    <div>
      <h2>Gerar Agenda</h2>
      {erro && <div className="alert error">{erro}</div>}

      <div className="card">
        <h3>Médicos</h3>
        <div className="form-row">
          <div style={{ flex: 1 }}>
            <AutocompleteMedico onSelect={aplicarModelo} />
          </div>
          <div style={{ flex: 2 }}>
            <label>Nome do médico</label>
            <input value={nomeMedico} onChange={e => setNomeMedico(e.target.value)} style={{ width: '100%' }} />
          </div>
        </div>

        <div className="form-row">
          <div>
            <label>Início (HH:mm)</label>
            <input type="time" value={inicioTmp} onChange={e => setInicioTmp(e.target.value)} />
          </div>
          <div>
            <label>Fim (HH:mm)</label>
            <input type="time" value={fimTmp} onChange={e => setFimTmp(e.target.value)} />
          </div>
          <div style={{ display: 'flex', alignItems: 'flex-end' }}>
            <button onClick={adicionarHorarioTmp}>Adicionar Horário</button>
          </div>
        </div>

        {horariosTmp.length > 0 && (
          <table className="table" style={{ marginBottom: 12 }}>
            <thead><tr><th>Início</th><th>Fim</th></tr></thead>
            <tbody>
              {horariosTmp.map((h, i) => <tr key={i}><td>{h.inicio}</td><td>{h.fim}</td></tr>)}
            </tbody>
          </table>
        )}

        <button onClick={adicionarMedico}>Adicionar Médico</button>

        {medicosAdicionados.length > 0 && (
          <table className="table" style={{ marginTop: 16 }}>
            <thead>
              <tr><th>Médico</th><th>Horários</th><th style={{ width: 100 }}></th></tr>
            </thead>
            <tbody>
              {medicosAdicionados.map((m, i) => (
                <tr key={i}>
                  <td>{m.nome}</td>
                  <td>{m.horariosDisponiveis.map(h => `${h.inicio}-${h.fim}`).join(', ')}</td>
                  <td><button className="btn-danger" onClick={() => removerMedico(i)}>X</button></td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

      <div className="card">
        <h3>Solicitações</h3>
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
            <button onClick={adicionarSolicitacao}>Adicionar</button>
          </div>
        </div>

        {solicitacoes.length > 0 && (
          <table className="table">
            <thead>
              <tr><th>Paciente</th><th>Duração</th><th>Prioridade</th><th style={{ width: 100 }}></th></tr>
            </thead>
            <tbody>
              {solicitacoes.map((s, i) => (
                <tr key={i}>
                  <td>{s.pacienteNome}</td>
                  <td>{s.duracaoMinutos} min</td>
                  <td>{s.prioridade}</td>
                  <td><button className="btn-danger" onClick={() => removerSolicitacao(i)}>X</button></td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

      <div className="card">
        <label style={{ display: 'flex', alignItems: 'center', gap: 8, cursor: 'pointer', margin: 0 }}>
          <input
            type="checkbox"
            checked={respeitarHoraAtual}
            onChange={e => setRespeitarHoraAtual(e.target.checked)}
          />
          Respeitar hora atual (só considera horários futuros)
        </label>
      </div>

      <button onClick={gerarAgenda} disabled={!podeGerar} style={{ padding: '12px 32px', fontSize: 16 }}>
        {gerando ? 'Gerando...' : 'Gerar Agenda'}
      </button>
    </div>
  );
}
