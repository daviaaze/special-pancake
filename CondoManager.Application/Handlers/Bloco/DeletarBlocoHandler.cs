using CondoManager.CQS.Commands.Bloco;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Bloco
{
    public class DeletarBlocoHandler : IRequestHandler<DeletarBlocoComando, IResultado>
    {

        private readonly IBlocoRepositorio _blocoRepositorio;

        public DeletarBlocoHandler(IBlocoRepositorio blocoRepositorio)
        {
            _blocoRepositorio = blocoRepositorio;
        }

        public Task<IResultado> Handle(DeletarBlocoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var bloco = _blocoRepositorio.Find(request.IdBloco);
                if (bloco is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                _blocoRepositorio.Delete(bloco);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
