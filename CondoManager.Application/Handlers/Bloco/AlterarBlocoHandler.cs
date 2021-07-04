using CondoManager.CQS.Commands.Bloco;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos.Validadores;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Bloco
{
    public class AlterarBlocoHandler : IRequestHandler<AlterarBlocoComando, IResultado>
    {

        private readonly IBlocoRepositorio _BlocoRepositorio;

        public AlterarBlocoHandler(IBlocoRepositorio blocoRepositorio)
        {
            _BlocoRepositorio = blocoRepositorio;
        }

        public Task<IResultado> Handle(AlterarBlocoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new BlocoDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var bloco = _BlocoRepositorio.Find(request.IdBloco);
                if (bloco is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                bloco.Alterar(request);

                _BlocoRepositorio.Update(bloco);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
