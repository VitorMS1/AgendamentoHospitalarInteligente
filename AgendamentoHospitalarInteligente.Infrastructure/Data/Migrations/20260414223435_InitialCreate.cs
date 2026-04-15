using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicosModelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosModelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicosAlocados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosAlocados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicosAlocados_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientesNaoAlocados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesNaoAlocados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacientesNaoAlocados_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoModeloHorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    Fim = table.Column<TimeOnly>(type: "time", nullable: false),
                    MedicoModeloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoModeloHorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoModeloHorarios_MedicosModelo_MedicoModeloId",
                        column: x => x.MedicoModeloId,
                        principalTable: "MedicosModelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoAlocadoId = table.Column<int>(type: "int", nullable: false),
                    PacienteNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorarioInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HorarioFim = table.Column<TimeOnly>(type: "time", nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_MedicosAlocados_MedicoAlocadoId",
                        column: x => x.MedicoAlocadoId,
                        principalTable: "MedicosAlocados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicoAlocadoHorarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    Fim = table.Column<TimeOnly>(type: "time", nullable: false),
                    MedicoAlocadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoAlocadoHorarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoAlocadoHorarios_MedicosAlocados_MedicoAlocadoId",
                        column: x => x.MedicoAlocadoId,
                        principalTable: "MedicosAlocados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AgendaId",
                table: "Consultas",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoAlocadoId",
                table: "Consultas",
                column: "MedicoAlocadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoAlocadoHorarios_MedicoAlocadoId",
                table: "MedicoAlocadoHorarios",
                column: "MedicoAlocadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoModeloHorarios_MedicoModeloId",
                table: "MedicoModeloHorarios",
                column: "MedicoModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicosAlocados_AgendaId",
                table: "MedicosAlocados",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesNaoAlocados_AgendaId",
                table: "PacientesNaoAlocados",
                column: "AgendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "MedicoAlocadoHorarios");

            migrationBuilder.DropTable(
                name: "MedicoModeloHorarios");

            migrationBuilder.DropTable(
                name: "PacientesNaoAlocados");

            migrationBuilder.DropTable(
                name: "MedicosAlocados");

            migrationBuilder.DropTable(
                name: "MedicosModelo");

            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
