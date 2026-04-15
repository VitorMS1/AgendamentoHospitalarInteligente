namespace AgendamentoHospitalarInteligente.Desktop.Models
{
    public class PagedResult<T>
    {
        public List<T> Itens { get; set; } = new();
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalPaginas { get; set; }
    }
}
