using CondoManager.CQS.Queries;
using CondoManager.CQS.ViewModels;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Condominio
{
    public class ObterCondominioPorFiltroHandler : IRequestHandler<ObterCondominioPorFiltroQuery, IResultadoPaginado>
    {
        private readonly ICondominioRepositorio _condominioRepositorio;

        public ObterCondominioPorFiltroHandler(ICondominioRepositorio condominioRepositorio)
        {
            _condominioRepositorio = condominioRepositorio;
        }

        public Task<IResultadoPaginado> Handle(ObterCondominioPorFiltroQuery request, CancellationToken cancellationToken)
        {
            try
            {
            var query = _condominioRepositorio.BuscarPorFiltro(request);

            return Task.FromResult(ResultadoPaginado.CriarSucesso(request, query, d => (CondominioViewModel)d));

            } catch (Exception ex)
            {
                return Task.FromResult(ResultadoPaginado.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
