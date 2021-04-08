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

        }
    }
}
