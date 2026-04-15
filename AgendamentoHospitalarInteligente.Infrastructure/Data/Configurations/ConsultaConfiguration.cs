using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Configurations
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consultas");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property<int>("MedicoAlocadoId");

            builder.HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey("MedicoAlocadoId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.PacienteNome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Prioridade)
                .IsRequired();

            builder.Property(c => c.Duracao)
                .IsRequired();

            builder.OwnsOne(c => c.Horario, h =>
            {
                h.Property(x => x.Inicio)
                    .HasColumnName("HorarioInicio")
                    .IsRequired();

                h.Property(x => x.Fim)
                    .HasColumnName("HorarioFim")
                    .IsRequired();
            });
        }
    }
}
