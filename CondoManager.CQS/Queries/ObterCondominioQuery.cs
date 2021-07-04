using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterCondominioQuery : IRequest<IResultado<CondominioViewModel>>
    {
        public ObterCondominioQuery(Guid id)
        {
            IdCondominio = id;
        }

        public Guid IdCondominio { get; }
    }
}
