using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Condominio
{
    public class DeletarCondominioComando : IRequest<IResultado>
    {
        public DeletarCondominioComando(Guid id)
        {
            IdCondominio = id;
        }

        public Guid IdCondominio { get; set; }
    }
}
