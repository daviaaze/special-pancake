using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Filtros;
using MediatR;

namespace CondoManager.CQS.Queries
{
    public class ObterBlocoPorFiltroQuery : BlocoFiltro, IRequest<IResultadoPaginado>
    {
    }
}
