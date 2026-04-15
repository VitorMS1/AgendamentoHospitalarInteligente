FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["AgendamentoHospitalarInteligente.Api/AgendamentoHospitalarInteligente.Api.csproj", "AgendamentoHospitalarInteligente.Api/"]
COPY ["AgendamentoHospitalarInteligente.Application/AgendamentoHospitalarInteligente.Application.csproj", "AgendamentoHospitalarInteligente.Application/"]
COPY ["AgendamentoHospitalarInteligente.Infrastructure/AgendamentoHospitalarInteligente.Infrastructure.csproj", "AgendamentoHospitalarInteligente.Infrastructure/"]
COPY ["AgendamentoHospitalarInteligente.Domain/AgendamentoHospitalarInteligente.Domain.csproj", "AgendamentoHospitalarInteligente.Domain/"]

RUN dotnet restore "AgendamentoHospitalarInteligente.Api/AgendamentoHospitalarInteligente.Api.csproj"

COPY . .
WORKDIR "/src/AgendamentoHospitalarInteligente.Api"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendamentoHospitalarInteligente.Api.dll"]
