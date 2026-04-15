using AgendamentoHospitalarInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AgendamentoHospitalarInteligente.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<MedicoModelo> MedicosModelo => Set<MedicoModelo>();
        public DbSet<Agenda> Agendas => Set<Agenda>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
