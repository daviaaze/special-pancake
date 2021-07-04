using CondoManager.CQS.Queries;
using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Apartamento
{
    public class ObterApartamentoHandler : IRequestHandler<ObterApartamentoQuery, IResultado<ApartamentoViewModel>>
    {
        private readonly IApartamentoRepositorio _apartamentoRepositorio;

        public ObterApartamentoHandler(IApartamentoRepositorio apartamentoRepositorio)
        {
            _apartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultado<ApartamentoViewModel>> Handle(ObterApartamentoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var apartamento = _apartamentoRepositorio.Find(request.IdApartamento);
                if (apartamento is null) return Task.FromResult(Resultado<ApartamentoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado));

                return Task.FromResult(Resultado<ApartamentoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.Ok, apartamento));

            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado<ApartamentoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
