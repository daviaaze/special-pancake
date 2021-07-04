using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Filtros;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterBlocoPorFiltroQuery : FiltroBase, IBlocoFiltro, IRequest<IResultadoPaginado>
    {
        public string Nome { get; set; }
        public Guid? IdCondominio { get; set; }
    }
}
