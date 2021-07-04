using CondoManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondoManager.Infra.Persistence.Mapeamentos
{
    public class MoradorMapeamento : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.ToTable("morador");
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Apartamento).WithMany(d => d.Moradores).HasForeignKey(d => d.IdApartamento);
        }
    }
}
