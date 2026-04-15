using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Configurations
{
    public class MedicoModeloConfiguration : IEntityTypeConfiguration<MedicoModelo>
    {
        public void Configure(EntityTypeBuilder<MedicoModelo> builder)
        {
            builder.ToTable("MedicosModelo");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsMany(m => m.HorariosDisponiveis, nav =>
            {
                nav.ToTable("MedicoModeloHorarios");

                nav.WithOwner().HasForeignKey("MedicoModeloId");
                nav.Property<int>("Id").ValueGeneratedOnAdd();
                nav.HasKey("Id");

                nav.Property(h => h.Inicio).HasColumnName("Inicio").IsRequired();

                nav.Property(h => h.Fim).HasColumnName("Fim").IsRequired();
            });

            builder.Navigation(m => m.HorariosDisponiveis)
                .HasField("_horariosDisponiveis");
        }
    }
}