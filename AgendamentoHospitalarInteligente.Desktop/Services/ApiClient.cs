using AgendamentoHospitalarInteligente.Desktop.Models;
using AgendamentoHospitalarInteligente.Desktop.Models.Enums;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AgendamentoHospitalarInteligente.Desktop.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<PagedResult<MedicoModeloResponse>> ObterMedicosAsync(int pagina = 1, int tamanhoPagina = 50)
        {
            return await EnviarAsync<PagedResult<MedicoModeloResponse>>(() => _http.GetAsync($"medicos?pagina={pagina}&tamanhoPagina={tamanhoPagina}"));
        }

        public async Task<List<MedicoModeloResponse>> BuscarMedicosAsync(string filtro, int limite = 10)
        {
            return await EnviarAsync<List<MedicoModeloResponse>>(() => _http.GetAsync($"medicos/buscar?filtro={Uri.EscapeDataString(filtro)}&limite={limite}"));
        }

        public async Task<MedicoModeloResponse> CriarMedicoAsync(string nome, List<HorarioDto> horarios)
        {
            return await EnviarAsync<MedicoModeloResponse>(() => _http.PostAsJsonAsync("medicos", new { nome, horariosDisponiveis = horarios }, JsonOptions));
        }

        public async Task<MedicoModeloResponse> AtualizarMedicoAsync(int id, string nome, List<HorarioDto> horarios)
        {
            return await EnviarAsync<MedicoModeloResponse>(() => _http.PutAsJsonAsync($"medicos/{id}", new { nome, horariosDisponiveis = horarios }, JsonOptions));
        }

        public async Task RemoverMedicoAsync(int id)
        {
            await EnviarAsync(() => _http.DeleteAsync($"medicos/{id}"));
        }

        public async Task<PagedResult<AgendaResponse>> ObterAgendasAsync(int pagina = 1, int tamanhoPagina = 50)
        {
            return await EnviarAsync<PagedResult<AgendaResponse>>(() => _http.GetAsync($"agendas?pagina={pagina}&tamanhoPagina={tamanhoPagina}"));
        }

        public async Task<AgendaResponse> ObterAgendaPorIdAsync(int id)
        {
            return await EnviarAsync<AgendaResponse>(() => _http.GetAsync($"agendas/{id}"));
        }

        public async Task<AgendaResponse> CriarAgendaAsync(object request)
        {
            return await EnviarAsync<AgendaResponse>(() => _http.PostAsJsonAsync("agendas", request, JsonOptions));
        }

        public async Task<AgendaResponse> EncaixarConsultaAsync(int agendaId, string pacienteNome, int duracaoMinutos, Prioridade prioridade, string? horaAtual)
        {
            var body = new { pacienteNome, duracaoMinutos, prioridade = prioridade.ToString(), horaAtual };
            return await EnviarAsync<AgendaResponse>(() => _http.PostAsJsonAsync($"agendas/{agendaId}/encaixar", body, JsonOptions));
        }

        public async Task RemoverAgendaAsync(int id)
        {
            await EnviarAsync(() => _http.DeleteAsync($"agendas/{id}"));
        }

        private async Task<T> EnviarAsync<T>(Func<Task<HttpResponseMessage>> requisicao)
        {
            var response = await requisicao();
            await GarantirSucessoAsync(response);
            return (await response.Content.ReadFromJsonAsync<T>(JsonOptions))!;
        }

        private async Task EnviarAsync(Func<Task<HttpResponseMessage>> requisicao)
        {
            var response = await requisicao();
            await GarantirSucessoAsync(response);
        }

        private static async Task GarantirSucessoAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;

            var statusCode = (int)response.StatusCode;
            var mensagem = await ExtrairMensagemErroAsync(response);
            throw new ApiException(statusCode, mensagem);
        }

        private static async Task<string> ExtrairMensagemErroAsync(HttpResponseMessage response)
        {
            try
            {
                var conteudo = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(conteudo))
                    return $"Erro {(int)response.StatusCode}: {response.ReasonPhrase}";

                using var doc = JsonDocument.Parse(conteudo);
                var raiz = doc.RootElement;

                if (raiz.TryGetProperty("erro", out var erro) && erro.ValueKind == JsonValueKind.String)
                    return erro.GetString()!;

                if (raiz.TryGetProperty("erros", out var erros) && erros.ValueKind == JsonValueKind.Array)
                {
                    var mensagens = erros.EnumerateArray()
                        .Select(e =>
                        {
                            var msg = e.TryGetProperty("mensagem", out var m) ? m.GetString() : null;
                            var campo = e.TryGetProperty("campo", out var c) ? c.GetString() : null;
                            return string.IsNullOrEmpty(campo) ? msg : $"• {msg}";
                        })
                        .Where(m => !string.IsNullOrWhiteSpace(m));

                    return "Foram encontrados os seguintes erros:\n\n" + string.Join("\n", mensagens);
                }

                return conteudo;
            }
            catch
            {
                return $"Erro {(int)response.StatusCode}: {response.ReasonPhrase}";
            }
        }
    }
}
