import { useEffect, useRef, useState } from 'react';
import { api } from '../services/api';
import type { MedicoModeloResponse } from '../types';

interface Props {
  onSelect: (medico: MedicoModeloResponse) => void;
}

const MIN_CHARS = 2;
const DEBOUNCE_MS = 300;

export default function AutocompleteMedico({ onSelect }: Props) {
  const [texto, setTexto] = useState('');
  const [resultados, setResultados] = useState<MedicoModeloResponse[]>([]);
  const [aberto, setAberto] = useState(false);
  const [buscou, setBuscou] = useState(false);
  const timerRef = useRef<ReturnType<typeof setTimeout> | null>(null);
  const containerRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    function handleClickFora(e: MouseEvent) {
      if (containerRef.current && !containerRef.current.contains(e.target as Node)) {
        setAberto(false);
      }
    }
    document.addEventListener('mousedown', handleClickFora);
    return () => document.removeEventListener('mousedown', handleClickFora);
  }, []);

  function handleChange(valor: string) {
    setTexto(valor);
    setBuscou(false);

    if (timerRef.current) clearTimeout(timerRef.current);

    if (valor.length < MIN_CHARS) {
      setResultados([]);
      setAberto(false);
      return;
    }

    timerRef.current = setTimeout(async () => {
      try {
        const res = await api.buscarMedicos(valor);
        setResultados(res);
        setBuscou(true);
        setAberto(true);
      } catch {
        setResultados([]);
        setBuscou(true);
        setAberto(true);
      }
    }, DEBOUNCE_MS);
  }

  function selecionar(medico: MedicoModeloResponse) {
    setTexto(`${medico.id} - ${medico.nome}`);
    setAberto(false);
    onSelect(medico);
  }

  return (
    <div ref={containerRef} className="autocomplete">
      <label>Buscar modelo existente</label>
      <input
        value={texto}
        onChange={e => handleChange(e.target.value)}
        placeholder="Digite o nome do médico..."
        style={{ width: '100%' }}
        onFocus={() => { if (resultados.length > 0 || buscou) setAberto(true); }}
      />
      {aberto && (
        <div className="autocomplete-dropdown">
          {resultados.length > 0 ? (
            resultados.map(m => (
              <div
                key={m.id}
                className="autocomplete-item"
                onMouseDown={() => selecionar(m)}
              >
                <strong>{m.id} - {m.nome}</strong>
                <span className="muted" style={{ marginLeft: 8, fontSize: 12 }}>
                  {m.horariosDisponiveis.map(h => `${h.inicio}-${h.fim}`).join(', ')}
                </span>
              </div>
            ))
          ) : (
            buscou && <div className="autocomplete-empty">Nenhum registro encontrado.</div>
          )}
        </div>
      )}
    </div>
  );
}
