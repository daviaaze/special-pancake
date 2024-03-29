﻿using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Filtros;
using MediatR;

namespace CondoManager.CQS.Queries
{
    public class ObterCondominioPorFiltroQuery : FiltroBase, ICondominioFiltro, IRequest<IResultadoPaginado>
    {
        public string Nome { get; set; }
    }
}
