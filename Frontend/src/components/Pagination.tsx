interface PaginationProps {
  pagina: number;
  totalRegistros: number;
  tamanhoPagina: number;
  onPageChange: (pagina: number) => void;
}

export default function Pagination({ pagina, totalRegistros, tamanhoPagina, onPageChange }: PaginationProps) {
  const totalPaginas = Math.max(1, Math.ceil(totalRegistros / tamanhoPagina));

  if (totalPaginas <= 1) return null;

  return (
    <div className="pagination">
      <button
        className="btn-secondary"
        disabled={pagina <= 1}
        onClick={() => onPageChange(pagina - 1)}
      >
        &larr; Anterior
      </button>
      <span className="pagination-info">
        Página {pagina} de {totalPaginas} ({totalRegistros} registros)
      </span>
      <button
        className="btn-secondary"
        disabled={pagina >= totalPaginas}
        onClick={() => onPageChange(pagina + 1)}
      >
        Próxima &rarr;
      </button>
    </div>
  );
}
