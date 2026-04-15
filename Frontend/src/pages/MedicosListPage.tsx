import { useEffect, useState } from 'react';
import { api } from '../services/api';
import type { HorarioDto, MedicoModeloResponse } from '../types';
import Pagination from '../components/Pagination';

const TAMANHO_PAGINA = 10;

export default function MedicosListPage() {
  const [medicos, setMedicos] = useState<MedicoModeloResponse[]>([]);
  const [pagina, setPagina] = useState(1);
  const [totalRegistros, setTotalRegistros] = useState(0);
  const [erro, setErro] = useState<string | null>(null);
  const [formAberto, setFormAberto] = useState(false);
  const [editandoId, setEditandoId] = useState<number | null>(null);
  const [nome, setNome] = useState('');
  const [horarios, setHorarios] = useState<HorarioDto[]>([]);
  const [inicioTmp, setInicioTmp] = useState('');
  const [fimTmp, setFimTmp] = useState('');

  async function carregar(pag: number) {
    try {
      const res = await api.listarMedicos(pag, TAMANHO_PAGINA);
      setMedicos(res.itens);
      setTotalRegistros(res.totalRegistros);
      setPagina(pag);
      setErro(null);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  useEffect(() => { carregar(1); }, []);

  function abrirNovo() {
    setEditandoId(null);
    setNome('');
    setHorarios([]);
    setFormAberto(true);
  }

  function abrirEdicao(m: MedicoModeloResponse) {
    setEditandoId(m.id);
    setNome(m.nome);
    setHorarios([...m.horariosDisponiveis]);
    setFormAberto(true);
  }

  function adicionarHorario() {
    if (!inicioTmp || !fimTmp) return;
    setHorarios([...horarios, { inicio: inicioTmp, fim: fimTmp }]);
    setInicioTmp('');
    setFimTmp('');
  }

  function removerHorario(idx: number) {
    setHorarios(horarios.filter((_, i) => i !== idx));
  }

  async function salvar() {
    try {
      if (editandoId) {
        await api.atualizarMedico(editandoId, { nome, horariosDisponiveis: horarios });
      } else {
        await api.criarMedico({ nome, horariosDisponiveis: horarios });
      }
      setFormAberto(false);
      await carregar(pagina);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  async function excluir(id: number, medicoNome: string) {
    if (!confirm(`Excluir ${medicoNome}?`)) return;
    try {
      await api.removerMedico(id);
      await carregar(pagina);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  return (
    <div>
      <div className="header-bar">
        <h2>Médicos (Modelos)</h2>
        <button onClick={abrirNovo}>+ Novo Médico</button>
      </div>

      {erro && <div className="alert error">{erro}</div>}

      <div className="card">
        <table className="table">
          <thead>
            <tr>
              <th>Id</th>
              <th>Nome</th>
              <th>Horários</th>
              <th style={{ width: 180 }}>Ações</th>
            </tr>
          </thead>
          <tbody>
            {medicos.map(m => (
              <tr key={m.id}>
                <td>{m.id}</td>
                <td>{m.nome}</td>
                <td>{m.horariosDisponiveis.map(h => `${h.inicio}-${h.fim}`).join(', ')}</td>
                <td>
                  <div className="row-actions">
                    <button className="btn-secondary" onClick={() => abrirEdicao(m)}>Editar</button>
                    <button className="btn-danger" onClick={() => excluir(m.id, m.nome)}>Excluir</button>
                  </div>
                </td>
              </tr>
            ))}
            {medicos.length === 0 && (
              <tr><td colSpan={4} className="muted">Nenhum médico cadastrado.</td></tr>
            )}
          </tbody>
        </table>
        <Pagination
          pagina={pagina}
          totalRegistros={totalRegistros}
          tamanhoPagina={TAMANHO_PAGINA}
          onPageChange={carregar}
        />
      </div>

      {formAberto && (
        <div className="card">
          <h3>{editandoId ? `Editar Médico #${editandoId}` : 'Novo Médico'}</h3>
          <div className="form-row">
            <div style={{ flex: 2 }}>
              <label>Nome</label>
              <input value={nome} onChange={e => setNome(e.target.value)} style={{ width: '100%' }} />
            </div>
          </div>

          <div className="form-row">
            <div>
              <label>Horário Início (HH:mm)</label>
              <input type="time" value={inicioTmp} onChange={e => setInicioTmp(e.target.value)} />
            </div>
            <div>
              <label>Horário Fim (HH:mm)</label>
              <input type="time" value={fimTmp} onChange={e => setFimTmp(e.target.value)} />
            </div>
            <div style={{ display: 'flex', alignItems: 'flex-end' }}>
              <button onClick={adicionarHorario}>Adicionar Horário</button>
            </div>
          </div>

          <table className="table">
            <thead>
              <tr>
                <th>Início</th>
                <th>Fim</th>
                <th style={{ width: 100 }}></th>
              </tr>
            </thead>
            <tbody>
              {horarios.map((h, i) => (
                <tr key={i}>
                  <td>{h.inicio}</td>
                  <td>{h.fim}</td>
                  <td><button className="btn-danger" onClick={() => removerHorario(i)}>X</button></td>
                </tr>
              ))}
              {horarios.length === 0 && (
                <tr><td colSpan={3} className="muted">Nenhum horário adicionado.</td></tr>
              )}
            </tbody>
          </table>

          <div className="actions" style={{ marginTop: 16 }}>
            <button onClick={salvar} disabled={!nome || horarios.length === 0}>Salvar</button>
            <button className="btn-secondary" onClick={() => setFormAberto(false)}>Cancelar</button>
          </div>
        </div>
      )}
    </div>
  );
}
