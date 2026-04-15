import type {
  AgendaResponse,
  AtualizarMedicoModeloRequest,
  CriarAgendaRequest,
  CriarMedicoModeloRequest,
  EncaixarConsultaRequest,
  MedicoModeloResponse,
  PagedResult
} from '../types';

const BASE_URL = import.meta.env.VITE_API_BASE_URL ?? 'http://localhost:5000/api';

class ApiError extends Error {
  status: number;
  constructor(status: number, message: string) {
    super(message);
    this.status = status;
  }
}

async function request<T>(path: string, options: RequestInit = {}): Promise<T> {
  const res = await fetch(`${BASE_URL}${path}`, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers ?? {})
    }
  });

  if (!res.ok) {
    const mensagem = await extrairMensagemErro(res);
    throw new ApiError(res.status, mensagem);
  }

  if (res.status === 204) return undefined as unknown as T;

  const text = await res.text();
  return text ? (JSON.parse(text) as T) : (undefined as unknown as T);
}

async function extrairMensagemErro(res: Response): Promise<string> {
  try {
    const body = await res.json();
    if (body?.erro) return body.erro;
    if (Array.isArray(body?.erros)) {
      return body.erros.map((e: { campo: string; mensagem: string }) => `${e.campo}: ${e.mensagem}`).join(' | ');
    }
    return JSON.stringify(body);
  } catch {
    return `Erro HTTP ${res.status}`;
  }
}

export const api = {
  // Medicos
  buscarMedicos: (filtro: string, limite = 10) =>
    request<MedicoModeloResponse[]>(`/medicos/buscar?filtro=${encodeURIComponent(filtro)}&limite=${limite}`),
  listarMedicos: (pagina = 1, tamanhoPagina = 50) =>
    request<PagedResult<MedicoModeloResponse>>(`/medicos?pagina=${pagina}&tamanhoPagina=${tamanhoPagina}`),
  obterMedico: (id: number) => request<MedicoModeloResponse>(`/medicos/${id}`),
  criarMedico: (body: CriarMedicoModeloRequest) =>
    request<MedicoModeloResponse>('/medicos', { method: 'POST', body: JSON.stringify(body) }),
  atualizarMedico: (id: number, body: AtualizarMedicoModeloRequest) =>
    request<MedicoModeloResponse>(`/medicos/${id}`, { method: 'PUT', body: JSON.stringify(body) }),
  removerMedico: (id: number) => request<void>(`/medicos/${id}`, { method: 'DELETE' }),

  // Agendas
  listarAgendas: (pagina = 1, tamanhoPagina = 50) =>
    request<PagedResult<AgendaResponse>>(`/agendas?pagina=${pagina}&tamanhoPagina=${tamanhoPagina}`),
  obterAgenda: (id: number) => request<AgendaResponse>(`/agendas/${id}`),
  criarAgenda: (body: CriarAgendaRequest) =>
    request<AgendaResponse>('/agendas', { method: 'POST', body: JSON.stringify(body) }),
  encaixar: (id: number, body: EncaixarConsultaRequest) =>
    request<AgendaResponse>(`/agendas/${id}/encaixar`, { method: 'POST', body: JSON.stringify(body) }),
  removerAgenda: (id: number) => request<void>(`/agendas/${id}`, { method: 'DELETE' })
};

export { ApiError };
