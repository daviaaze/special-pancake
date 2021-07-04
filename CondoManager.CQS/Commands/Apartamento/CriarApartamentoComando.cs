using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Apartamento
{
    public class CriarApartamentoComando : ApartamentoDto, IRequest<IResultado> 
    {
        public Guid IdBloco { get; set; }
    }
}
