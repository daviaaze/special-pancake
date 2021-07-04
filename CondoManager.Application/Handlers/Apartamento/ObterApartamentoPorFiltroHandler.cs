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
    public class ObterApartamentoPorFiltroHandler : IRequestHandler<ObterApartamentoPorFiltroQuery, IResultadoPaginado>
    {
        private readonly IApartamentoRepositorio _apartamentoRepositorio;

        public ObterApartamentoPorFiltroHandler(IApartamentoRepositorio apartamentoRepositorio)
        {
            _apartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultadoPaginado> Handle(ObterApartamentoPorFiltroQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _apartamentoRepositorio.BuscarPorFiltro(request);

                return Task.FromResult(ResultadoPaginado.CriarSucesso(request, query, d => (ApartamentoViewModel)d));

            }
            catch (Exception ex)
            {
                return Task.FromResult(ResultadoPaginado.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
