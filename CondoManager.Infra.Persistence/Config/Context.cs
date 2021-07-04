using CondoManager.Domain.Entidades;
using CondoManager.Infra.Persistence.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;

namespace CondoManager.Infra.Persistence.Config
{
    public class Context : DbContext
    {
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Morador> Moradores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))
                          .UseLowerCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApartamentoMapeamento());
            modelBuilder.ApplyConfiguration(new BlocoMapeamento());
            modelBuilder.ApplyConfiguration(new CondominioMapeamento());
            modelBuilder.ApplyConfiguration(new MoradorMapeamento());
        }
    }
}
