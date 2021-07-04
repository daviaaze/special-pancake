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

        private readonly IBlocoRepositorio _blocoRepositorio;
        private readonly ICondominioRepositorio _CondominioRepositorio;

        public CriarBlocoHandler(IBlocoRepositorio blocoRepositorio, ICondominioRepositorio condominioRepositorio)
        {
            _blocoRepositorio = blocoRepositorio;
            _CondominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado> Handle(CriarBlocoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new BlocoDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var condominio = _CondominioRepositorio.Find(request.IdCondominio);
                if (condominio is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado).AdicionarMensagem("Condominio não encontrado"));

                var bloco = new Domain.Entidades.Bloco(request, condominio);

                _blocoRepositorio.Add(bloco);

                _blocoRepositorio.Save();

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
