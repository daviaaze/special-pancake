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
    public class ObterBlocoHandler : IRequestHandler<ObterBlocoQuery, IResultado<BlocoViewModel>>
    {
        private readonly IBlocoRepositorio _blocoRepositorio;

        public ObterBlocoHandler(IBlocoRepositorio blocoRepositorio)
        {
            _blocoRepositorio = blocoRepositorio;
        }

        public Task<IResultado<BlocoViewModel>> Handle(ObterBlocoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloco = _blocoRepositorio.Find(request.IdBloco);
                if (bloco is null) return Task.FromResult(Resultado<BlocoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado));

                return Task.FromResult(Resultado<BlocoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.Ok, bloco));

            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado<BlocoViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
