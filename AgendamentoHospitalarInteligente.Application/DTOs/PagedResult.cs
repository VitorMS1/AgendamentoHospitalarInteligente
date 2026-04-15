namespace AgendamentoHospitalarInteligente.Application.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Itens { get; set; } = Enumerable.Empty<T>();
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamanhoPagina);
    }
}
