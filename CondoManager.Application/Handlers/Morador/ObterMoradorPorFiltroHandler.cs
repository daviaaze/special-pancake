using CondoManager.CQS.Queries;
using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Morador
{
    public class ObterMoradorPorFiltroHandler : IRequestHandler<ObterMoradorPorFiltroQuery, IResultadoPaginado>
    {
        private readonly IMoradorRepositorio _moradorRepositorio;

        public ObterMoradorPorFiltroHandler(IMoradorRepositorio moradorRepositorio)
        {
            _moradorRepositorio = moradorRepositorio;
        }

        public Task<IResultadoPaginado> Handle(ObterMoradorPorFiltroQuery request, CancellationToken cancellationToken)
        {
            try
            {
            var query = _moradorRepositorio.BuscarPorFiltro(request);

            return Task.FromResult(ResultadoPaginado.CriarSucesso(request, query, d => (MoradorViewModel)d));

            } catch (Exception ex)
            {
                return Task.FromResult(ResultadoPaginado.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
