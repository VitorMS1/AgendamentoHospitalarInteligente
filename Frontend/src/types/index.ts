export type Prioridade = 'Baixa' | 'Media' | 'Alta';

export interface HorarioDto {
  inicio: string;
  fim: string;
}

export interface MedicoModeloResponse {
  id: number;
  nome: string;
  horariosDisponiveis: HorarioDto[];
}

export interface MedicoAlocadoResponse {
  id: number;
  nome: string;
  horariosDisponiveis: HorarioDto[];
}

export interface ConsultaResponse {
  id: number;
  medicoId: number;
  medicoNome: string;
  pacienteNome: string;
  prioridade: Prioridade;
  duracaoMinutos: number;
  horarioInicio: string;
  horarioFim: string;
}

export interface PacienteNaoAlocadoResponse {
  nome: string;
  duracaoMinutos: number;
  prioridade: Prioridade;
}

export interface AgendaResponse {
  id: number;
  data: string;
  medicos: MedicoAlocadoResponse[];
  consultas: ConsultaResponse[];
  pacientesNaoAlocados: PacienteNaoAlocadoResponse[];
}

export interface PagedResult<T> {
  itens: T[];
  totalRegistros: number;
  pagina: number;
  tamanhoPagina: number;
}

export interface MedicoAgendaDto {
  nome: string;
  horariosDisponiveis: HorarioDto[];
}

export interface SolicitacaoDto {
  pacienteNome: string;
  duracaoMinutos: number;
  prioridade: Prioridade;
}

export interface CriarAgendaRequest {
  medicos: MedicoAgendaDto[];
  solicitacoes: SolicitacaoDto[];
  horaAtual?: string | null;
}

export interface EncaixarConsultaRequest {
  pacienteNome: string;
  duracaoMinutos: number;
  prioridade: Prioridade;
  horaAtual?: string | null;
}

export interface CriarMedicoModeloRequest {
  nome: string;
  horariosDisponiveis: HorarioDto[];
}

export interface AtualizarMedicoModeloRequest {
  nome: string;
  horariosDisponiveis: HorarioDto[];
}
