using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Filtros;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterMoradorPorFiltroQuery : FiltroBase, IMoradorFiltro, IRequest<IResultadoPaginado>
    {
        public string Nome { get; set; }
        public Guid? IdApartamento { get; set; }
        public int? Andar { get; set; }
        public Guid? IdCondominio { get; set; }
        public Guid? IdBloco { get; set; }
    }
}
