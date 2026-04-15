using AgendamentoHospitalarInteligente.Application.Exceptions;
using AgendamentoHospitalarInteligente.Domain.Exceptions;
using FluentValidation;

namespace AgendamentoHospitalarInteligente.Application.Mappings
{
    public class ExceptionMapper : IExceptionMapper
    {
        public (int StatusCode, object Body) Map(Exception exception) => exception switch
        {
            OperationCanceledException => (499, new { erro = "Requisição cancelada pelo cliente." }),
            ValidationException ex => (400, new { erros = ex.Errors.Select(e => new { campo = e.PropertyName, mensagem = e.ErrorMessage })}),
            DomainValidationException ex => (400, new { erro = ex.Message }),
            ResourceNotFoundException ex => (404, new { erro = ex.Message }),
            DomainException ex => (422, new { erro = ex.Message }),
            _ => (500, new { erro = "Ocorreu um erro interno no servidor." })
        };
    }
}
