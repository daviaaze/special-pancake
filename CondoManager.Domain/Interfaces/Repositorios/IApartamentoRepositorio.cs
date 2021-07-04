using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using System;
using System.Linq;

namespace CondoManager.Domain.Interfaces.Repositorios
{
    public interface IApartamentoRepositorio : IRepository<Apartamento>, IDisposable
    {
        IQueryable<Apartamento> BuscarPorFiltro(IApartamentoFiltro filtro);
    }
}
