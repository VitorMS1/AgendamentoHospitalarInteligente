import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { api } from '../services/api';
import type { AgendaResponse } from '../types';
import Pagination from '../components/Pagination';

const TAMANHO_PAGINA = 10;

export default function AgendasListPage() {
  const [agendas, setAgendas] = useState<AgendaResponse[]>([]);
  const [pagina, setPagina] = useState(1);
  const [totalRegistros, setTotalRegistros] = useState(0);
  const [erro, setErro] = useState<string | null>(null);

  async function carregar(pag: number) {
    try {
      const res = await api.listarAgendas(pag, TAMANHO_PAGINA);
      setAgendas(res.itens);
      setTotalRegistros(res.totalRegistros);
      setPagina(pag);
      setErro(null);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  useEffect(() => { carregar(1); }, []);

  async function excluir(id: number) {
    if (!confirm('Deseja excluir esta agenda?')) return;
    try {
      await api.removerAgenda(id);
      await carregar(pagina);
    } catch (e) {
      setErro((e as Error).message);
    }
  }

  return (
    <div>
      <h2>Agendas</h2>
      {erro && <div className="alert error">{erro}</div>}

      <div className="card">
        <table className="table">
          <thead>
            <tr>
              <th>Id</th>
              <th>Data</th>
              <th>Consultas</th>
              <th>Não Alocados</th>
              <th style={{ width: 220 }}>Ações</th>
            </tr>
          </thead>
          <tbody>
            {agendas.map(a => (
              <tr key={a.id}>
                <td>#{a.id}</td>
                <td>{new Date(a.data).toLocaleString('pt-BR')}</td>
                <td>{a.consultas.length}</td>
                <td>{a.pacientesNaoAlocados.length}</td>
                <td>
                  <div className="row-actions">
                    <Link to={`/agendas/${a.id}`}><button className="btn-secondary">Detalhes</button></Link>
                    <button className="btn-danger" onClick={() => excluir(a.id)}>Excluir</button>
                  </div>
                </td>
              </tr>
            ))}
            {agendas.length === 0 && (
              <tr><td colSpan={5} className="muted">Nenhuma agenda cadastrada.</td></tr>
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
    </div>
  );
}
