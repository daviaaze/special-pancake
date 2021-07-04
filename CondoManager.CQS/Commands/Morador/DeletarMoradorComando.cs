using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Morador
{
    public class DeletarMoradorComando : IRequest<IResultado>
    {
        public DeletarMoradorComando(Guid id)
        {
            IdMorador = id;
        }

        public Guid IdMorador { get; set; }
    }
}
