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
    public class AlterarCondominioHandler : IRequestHandler<AlterarCondominioComando, IResultado>
    {

        private readonly ICondominioRepositorio _condominioRepositorio;

        public AlterarCondominioHandler(ICondominioRepositorio condominioRepositorio)
        {
            _condominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado> Handle(AlterarCondominioComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new CondominioDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var condominio = _condominioRepositorio.Find(request.IdCondominio);
                if (condominio is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                condominio.Alterar(request);

                _condominioRepositorio.Update(condominio);

                _condominioRepositorio.Save();

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
