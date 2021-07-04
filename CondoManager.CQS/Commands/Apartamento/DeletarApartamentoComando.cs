using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Apartamento
{
    public class DeletarApartamentoComando : IRequest<IResultado>
    {
        public DeletarApartamentoComando(Guid id)
        {
            IdApartamento = id;
        }

        public Guid IdApartamento { get; set; }
    }
}
