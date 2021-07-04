using CondoManager.CQS.Queries;
using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Bloco
{
    public class ObterBlocoPorFiltroHandler : IRequestHandler<ObterBlocoPorFiltroQuery, IResultadoPaginado>
    {
        private readonly IBlocoRepositorio _blocoRepositorio;

        public ObterBlocoPorFiltroHandler(IBlocoRepositorio blocoRepositorio)
        {
            _blocoRepositorio = blocoRepositorio;
        }

        public Task<IResultadoPaginado> Handle(ObterBlocoPorFiltroQuery request, CancellationToken cancellationToken)
        {
            try
            {
            var query = _blocoRepositorio.BuscarPorFiltro(request);

            return Task.FromResult(ResultadoPaginado.CriarSucesso(request, query, d => (BlocoViewModel)d));

            } catch (Exception ex)
            {
                return Task.FromResult(ResultadoPaginado.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
