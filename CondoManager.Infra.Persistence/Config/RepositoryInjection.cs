using CondoManager.Domain.Interfaces.Repositorios;
using CondoManager.Infra.Persistence.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace CondoManager.Infra.Persistence.Config
{
    public static class RepositoryInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICondominioRepositorio, CondominioRepositorio>();
            services.AddScoped<IBlocoRepositorio, BlocoRepositorio>();
            services.AddScoped<IMoradorRepositorio, MoradorRepositorio>();
            services.AddScoped<IApartamentoRepositorio, ApartamentoRepositorio>();
        }
    }
}
