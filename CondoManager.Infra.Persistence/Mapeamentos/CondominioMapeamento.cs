using CondoManager.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CondoManager.Infra.Persistence.Mapeamentos
{
    public class CondominioMapeamento : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.ToTable("condominio");
            builder.HasKey(d => d.Id);
        }
    }
}
