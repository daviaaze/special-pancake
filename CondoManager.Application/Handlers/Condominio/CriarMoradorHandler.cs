using CondoManager.CQS.Commands.Condominio;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos.Validadores;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Condominio
{
    public class CriarCondominioHandler : IRequestHandler<CriarCondominioComando, IResultado>
    {

        private readonly ICondominioRepositorio _condominioRepositorio;

        public CriarCondominioHandler(ICondominioRepositorio condominioRepositorio)
        {
            _condominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado> Handle(CriarCondominioComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new CondominioDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var condominio = new Domain.Entidades.Condominio(request);

                _condominioRepositorio.Add(condominio);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
