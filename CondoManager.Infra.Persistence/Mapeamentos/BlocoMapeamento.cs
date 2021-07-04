using CondoManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CondoManager.Infra.Persistence.Mapeamentos
{
    public class BlocoMapeamento : IEntityTypeConfiguration<Bloco>
    {
        public void Configure(EntityTypeBuilder<Bloco> builder)
        {
            builder.ToTable("bloco");
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Condominio).WithMany(d => d.Blocos).HasForeignKey(d => d.IdCondominio);
        }
    }
}
