using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Bloco
{
    public class CriarBlocoComando : BlocoDto, IRequest<IResultado> 
    {
        public Guid IdCondominio { get; set; }
    }
}
