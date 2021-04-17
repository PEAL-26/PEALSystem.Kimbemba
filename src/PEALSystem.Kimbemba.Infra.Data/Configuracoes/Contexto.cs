using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PEALSystem.Kimbemba.Infra.Data.Mapeamentos;

namespace PEALSystem.Kimbemba.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new CodigoBarraMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.MySQLConfiguration();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
