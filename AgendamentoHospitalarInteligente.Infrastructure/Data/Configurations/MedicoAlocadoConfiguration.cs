using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Configurations
{
    public class MedicoAlocadoConfiguration : IEntityTypeConfiguration<MedicoAlocado>
    {
        public void Configure(EntityTypeBuilder<MedicoAlocado> builder)
        {
            builder.ToTable("MedicosAlocados");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsMany(m => m.HorariosDisponiveis, nav =>
            {
                nav.ToTable("MedicoAlocadoHorarios");

                nav.WithOwner().HasForeignKey("MedicoAlocadoId");
                nav.Property<int>("Id").ValueGeneratedOnAdd();
                nav.HasKey("Id");

                nav.Property(h => h.Inicio)
                    .HasColumnName("Inicio")
                    .IsRequired();

                nav.Property(h => h.Fim)
                    .HasColumnName("Fim")
                    .IsRequired();
            });

            builder.Navigation(m => m.HorariosDisponiveis)
                .HasField("_horariosDisponiveis");
        }
    }
}