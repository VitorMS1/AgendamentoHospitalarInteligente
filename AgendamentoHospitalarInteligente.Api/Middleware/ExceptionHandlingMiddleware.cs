using AgendamentoHospitalarInteligente.Application.Mappings;
using System.Text.Json;

namespace AgendamentoHospitalarInteligente.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IExceptionMapper _exceptionMapper;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IExceptionMapper exceptionMapper)
        {
            _next = next;
            _logger = logger;
            _exceptionMapper = exceptionMapper;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var (statusCode, body) = _exceptionMapper.Map(ex);

                if (statusCode == 500)
                    _logger.LogError(ex, "Erro interno não tratado");

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var resposta = JsonSerializer.Serialize(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                await context.Response.WriteAsync(resposta);
            }
        }
    }
}
