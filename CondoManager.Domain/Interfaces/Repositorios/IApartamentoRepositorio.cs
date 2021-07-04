﻿using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using System.Linq;

namespace CondoManager.Domain.Interfaces.Repositorios
{
    public interface IApartamentoRepositorio : IRepository<Apartamento>
    {
        IQueryable<Apartamento> FindByFilter(ApartamentoFiltro filtro);
    }
}