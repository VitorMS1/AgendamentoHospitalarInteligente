using AgendamentoHospitalarInteligente.Desktop.Forms;
using AgendamentoHospitalarInteligente.Desktop.Services;
using Microsoft.Extensions.Configuration;

namespace AgendamentoHospitalarInteligente.Desktop;

static class Program
{
    public static ApiClient Api { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var apiBaseUrl = configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("ApiBaseUrl não configurada no appsettings.json");

        var http = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
        Api = new ApiClient(http);

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
