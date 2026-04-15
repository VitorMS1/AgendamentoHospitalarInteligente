namespace AgendamentoHospitalarInteligente.Application.Mappings
{
    public interface IExceptionMapper
    {
        (int StatusCode, object Body) Map(Exception exception);
    }
}
