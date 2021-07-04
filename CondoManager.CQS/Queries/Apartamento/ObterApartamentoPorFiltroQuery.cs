using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Filtros;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterApartamentoPorFiltroQuery : FiltroBase, IApartamentoFiltro, IRequest<IResultadoPaginado>
    {
        public int? Andar { get; set; }
        public Guid? IdCondominio { get; set; }
        public Guid? IdBloco { get; set; }
    }
}
