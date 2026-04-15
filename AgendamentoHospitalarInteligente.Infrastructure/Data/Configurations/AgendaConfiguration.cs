using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Configurations
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agendas");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Data)
                .IsRequired();

            builder.HasMany(a => a.Medicos)
                .WithOne()
                .HasForeignKey("AgendaId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(a => a.Medicos)
                .HasField("_medicos");

            builder.HasMany(a => a.Consultas)
                .WithOne()
                .HasForeignKey("AgendaId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(a => a.Consultas)
                .HasField("_consultas");

            builder.HasMany(a => a.PacientesNaoAlocados)
                .WithOne()
                .HasForeignKey("AgendaId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(a => a.PacientesNaoAlocados)
                .HasField("_pacientesNaoAlocados");
        }
    }
}
