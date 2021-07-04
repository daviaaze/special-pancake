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
    public class CriarBlocoHandler : IRequestHandler<CriarBlocoComando, IResultado>
    {

        private readonly IBlocoRepositorio _BlocoRepositorio;
        private readonly ICondominioRepositorio _CondominioRepositorio;

        public CriarBlocoHandler(IBlocoRepositorio blocoRepositorio, ICondominioRepositorio condominioRepositorio)
        {
            _BlocoRepositorio = blocoRepositorio;
            _CondominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado> Handle(CriarBlocoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new BlocoDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var condominio = _CondominioRepositorio.Find(request.IdCondominio);
                if(condominio is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok).AdicionarMensagem("Condominio não encontrado"));

                var bloco = new Domain.Entidades.Bloco(request, condominio);

                _BlocoRepositorio.Add(bloco);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
