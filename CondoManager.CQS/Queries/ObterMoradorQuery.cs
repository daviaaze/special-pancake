using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core.Interfaces;
using MediatR;
using System;

namespace CondoManager.CQS.Queries
{
    public class ObterMoradorQuery : IRequest<IResultado<MoradorViewModel>>
    {
        public ObterMoradorQuery(Guid id)
        {
            IdMorador = id;
        }

        public Guid IdMorador { get; }
    }
}
