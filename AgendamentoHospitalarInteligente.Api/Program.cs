using AgendamentoHospitalarInteligente.Api.Middleware;
using AgendamentoHospitalarInteligente.Application.Mappings;
using AgendamentoHospitalarInteligente.Application.UseCases.Agenda;
using AgendamentoHospitalarInteligente.Application.UseCases.MedicoModelo;
using AgendamentoHospitalarInteligente.Application.Validations;
using AgendamentoHospitalarInteligente.Domain.Interfaces;
using AgendamentoHospitalarInteligente.Infrastructure.Data.Context;
using AgendamentoHospitalarInteligente.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMedicoModeloRepository, MedicoModeloRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CriarAgendaRequestValidator>();

builder.Services.AddSingleton<IExceptionMapper, ExceptionMapper>();

builder.Services.AddScoped<IMedicoModeloUseCase, MedicoModeloUseCase>();
builder.Services.AddScoped<IAgendaUseCase, AgendaUseCase>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    for (var tentativa = 1; tentativa <= 10; tentativa++)
    {
        try
        {
            db.Database.Migrate();
            logger.LogInformation("Migrations aplicadas com sucesso.");
            break;
        }
        catch (Exception ex)
        {
            logger.LogWarning("Tentativa {Tentativa}/10 - Aguardando banco de dados... ({Erro})", tentativa, ex.Message);
            if (tentativa == 10) throw;
            Thread.Sleep(3000);
        }
    }
}

app.UseCors();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
    app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
