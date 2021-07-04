using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterBlocoQuery : IRequest<IResultado<BlocoViewModel>>
    {
        public ObterBlocoQuery(Guid id)
        {
            IdBloco = id;
        }

        public Guid IdBloco { get; }
    }
}
