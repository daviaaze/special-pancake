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
    public class ObterMoradorHandler : IRequestHandler<ObterMoradorQuery, IResultado<MoradorViewModel>>
    {
        private readonly IMoradorRepositorio _moradorRepositorio;

        public ObterMoradorHandler(IMoradorRepositorio moradorRepositorio)
        {
            _moradorRepositorio = moradorRepositorio;
        }

        public Task<IResultado<MoradorViewModel>> Handle(ObterMoradorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var morador = _moradorRepositorio.Find(request.IdMorador);
                if (morador is null) return Task.FromResult(Resultado<MoradorViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.NaoEncontrado));

                return Task.FromResult(Resultado<MoradorViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.Ok, morador));

            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado<MoradorViewModel>.Criar(Domain.Core.Enums.EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
