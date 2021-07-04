using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using System;
using System.Linq;

namespace CondoManager.Domain.Interfaces.Repositorios
{
    public interface IMoradorRepositorio : IRepository<Morador>, IDisposable
    {
        IQueryable<Morador> FindByFilter(IMoradorFiltro filtro);
    }
}
