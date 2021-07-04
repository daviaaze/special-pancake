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
    public class ObterCondominioHandler : IRequestHandler<ObterCondominioQuery, IResultado<CondominioViewModel>>
    {
        private readonly ICondominioRepositorio _condominioRepositorio;

        public ObterCondominioHandler(ICondominioRepositorio condominioRepositorio)
        {
            _condominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado<CondominioViewModel>> Handle(ObterCondominioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var condominio = _condominioRepositorio.Find(request.IdCondominio);
                if (condominio is null) return Task.FromResult(Resultado<CondominioViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado));

                return Task.FromResult(Resultado<CondominioViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.Ok, condominio));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado<CondominioViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
