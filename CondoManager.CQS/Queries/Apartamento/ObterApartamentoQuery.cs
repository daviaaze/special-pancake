using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterApartamentoQuery : IRequest<IResultado<ApartamentoViewModel>>
    {
        public ObterApartamentoQuery(Guid id)
        {
            IdApartamento = id;
        }

        public Guid IdApartamento { get; }
    }
}
