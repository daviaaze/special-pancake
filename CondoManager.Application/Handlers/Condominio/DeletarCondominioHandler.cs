using CondoManager.CQS.Commands.Condominio;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Condominio
{
    public class DeletarCondominioHandler : IRequestHandler<DeletarCondominioComando, IResultado>
    {

        private readonly ICondominioRepositorio _condominioRepositorio;

        public DeletarCondominioHandler(ICondominioRepositorio condominioRepositorio)
        {
            _condominioRepositorio = condominioRepositorio;
        }

        public Task<IResultado> Handle(DeletarCondominioComando request, CancellationToken cancellationToken)
        {
            try
            {
                var condominio = _condominioRepositorio.Find(request.IdCondominio);
                if (condominio is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                _condominioRepositorio.Delete(condominio);

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
