import type { Prioridade } from '../types';

export default function PrioridadeTag({ value }: { value: Prioridade }) {
  return <span className={`tag ${value.toLowerCase()}`}>{value}</span>;
}
