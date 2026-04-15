# ====== Agendamento Hospitalar

 Sistema de agendamento que aloca pacientes em consultas, otimizando o uso do tempo disponivel dos medicos.

## Sobre o Projeto

 O sistema recebe uma lista de medicos com seus horários disponíveis e uma lista de solicitacoes de pacientes (com duracao e prioridade), e gera automaticamente uma agenda otimizada. Alem da geracao inicial, permite encaixes posteriores com reorganizacao automática das consultas existentes.

- Alocar pacientes nos medicos disponiveis priorizando por urgencia e buscando o horário  mais cedo entre todos os medicos
- Encaixar um novo paciente, reorganizando consultas
- CRUD de modelos de medicos para reutilizacao

## Arquitetura, Padroes e Principios

 O projeto segue conceitos de Clean Architecture e DDD. Com emprego do padrão Repository e princípios SOLID. A divisão foi feita nas camadas:
- AgendamentoHospitalarInteligente.Domain
- AgendamentoHospitalarInteligente.Application
- AgendamentoHospitalarInteligente.Infrastructure
- AgendamentoHospitalarInteligente.Api

- AgendamentoHospitalarInteligente.Tests
- AgendamentoHospitalarInteligente.Desktop
- Projeto Frontend 

## Tecnologias

- .NET 8 / C# 12
- ASP.NET Core (REST API)
- Entity Framework Core 8 (Code-First)
- SQL Server
- FluentValidation
- Docker / Docker Compose

- React 18
- TypeScript
- Vite
- React Router DOM

- Windows Forms (.NET 8)
- System.Text.Json

- xUnit
- FluentAssertions

## Pre-requisitos

- Docker Desktop (para API + SQL Server)
- .NET 8 SDK (para Desktop e Testes)
- Node.js 18+ (para Frontend Web)

## Como Executar

### 1. API + Banco de Dados (Docker)

```bash
# Na raiz do projeto
docker compose up -d --build
```

A API sobe em **http://localhost:5000** com Swagger disponivel em **http://localhost:5000/swagger**.

Para parar:

```bash
docker compose down
```

### 2. Frontend Web

```bash
cd frontend
npm install
npm run dev
```

Abre em **http://localhost:5173**. Consome a API em `http://localhost:5000/api`.

Para alterar a URL da API, edite `frontend/.env`:

### 3. Desktop (Windows Forms)

Abra a solution `AgendamentoHospitalarInteligente.slnx` no Visual Studio e execute o projeto `AgendamentoHospitalarInteligente.Desktop`.

Ou via terminal:

```bash
dotnet run --project AgendamentoHospitalarInteligente.Desktop
```

A URL da API e configurada em `AgendamentoHospitalarInteligente.Desktop/appsettings.json`.

### 4. Testes Unitarios

```bash
dotnet test
```