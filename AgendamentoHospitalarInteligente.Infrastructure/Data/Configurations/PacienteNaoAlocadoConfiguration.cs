using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Configurations
{
    public class PacienteNaoAlocadoConfiguration : IEntityTypeConfiguration<PacienteNaoAlocado>
    {
        public void Configure(EntityTypeBuilder<PacienteNaoAlocado> builder)
        {
            builder.ToTable("PacientesNaoAlocados");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Duracao)
                .IsRequired();

            builder.Property(p => p.Prioridade)
                .IsRequired();
        }
    }
}
