using CondoManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondoManager.Infra.Persistence.Mapeamentos
{
    public class ApartamentoMapeamento : IEntityTypeConfiguration<Apartamento>
    {
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.ToTable("apartamento");
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Bloco).WithMany(d => d.Apartamentos).HasForeignKey(d => d.IdBloco);
        }
    }
}
