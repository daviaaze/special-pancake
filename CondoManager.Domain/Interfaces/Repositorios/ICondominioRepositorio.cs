using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using System;
using System.Linq;

namespace CondoManager.Domain.Interfaces.Repositorios
{
    public interface ICondominioRepositorio : IRepository<Condominio>, IDisposable
    {
        IQueryable<Condominio> FindByFilter(ICondominioFiltro filtro);
    }
}
