using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Morador
{
    public class CriarMoradorComando : MoradorDto, IRequest<IResultado>
    {
        public Guid IdApartamento { get; set; }
    }
}
