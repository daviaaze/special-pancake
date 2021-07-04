using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Bloco
{
    public class AlterarBlocoComando : BlocoDto, IRequest<IResultado>
    {
        public AlterarBlocoComando(Guid id, BlocoDto input)
        {
            IdBloco = id;
            Nome = input.Nome;
        }

        public Guid IdBloco { get; set; }
    }
}
