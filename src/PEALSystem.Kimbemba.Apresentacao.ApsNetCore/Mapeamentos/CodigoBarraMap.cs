using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PEALSystem.Kimbemba.Models;

namespace PEALSystem.Kimbemba.Mapeamentos
{
    public class CodigoBarraMap : IEntityTypeConfiguration<CodigoBarra>
    {
        public void Configure(EntityTypeBuilder<CodigoBarra> builder)
        {
            builder.ToTable("codigo_barras")
                .HasKey(k=>k.Codigo);
            
            builder.HasIndex(i => i.CodigoAEN)
                .IsUnique();

            builder.Property(m => m.Codigo)
                  .HasColumnName("Codigo")
                  .HasColumnType("varchar(14)")
                  .IsRequired();  

            builder.Property(m => m.CodigoAEN)
                  .HasColumnName("CodigoAEN")
                  .HasColumnType("varchar(14)")
                  .IsRequired();  
            
            builder.Property(m => m.Data)
                  .HasColumnName("Data")
                  .HasColumnType("date")
                  .IsRequired();

            builder.Property(m => m.Numero)
                  .HasColumnName("Numero")
                  .HasColumnType("int")
                  .IsRequired();

        }
    }
}
