using CondoManager.CQS.Commands.Morador;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos.Validadores;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Morador
{
    public class DeletarMoradorHandler : IRequestHandler<DeletarMoradorComando, IResultado>
    {

        private readonly IMoradorRepositorio _moradorRepositorio;

        public DeletarMoradorHandler(IMoradorRepositorio moradorRepositorio)
        {
            _moradorRepositorio = moradorRepositorio;
        }

        public Task<IResultado> Handle(DeletarMoradorComando request, CancellationToken cancellationToken)
        {
            try
            {
                var morador = _moradorRepositorio.Find(request.IdMorador);
                if (morador is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                _moradorRepositorio.Delete(morador);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
