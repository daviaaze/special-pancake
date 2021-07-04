using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Bloco
{
    public class DeletarBlocoComando : IRequest<IResultado>
    {
        public DeletarBlocoComando(Guid id)
        {
            IdBloco = id;
        }

        public Guid IdBloco { get; set; }
    }
}
