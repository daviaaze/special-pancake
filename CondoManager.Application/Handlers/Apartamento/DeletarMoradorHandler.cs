using CondoManager.CQS.Commands.Apartamento;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Apartamento
{
    public class DeletarApartamentoHandler : IRequestHandler<DeletarApartamentoComando, IResultado>
    {

        private readonly IApartamentoRepositorio _apartamentoRepositorio;

        public DeletarApartamentoHandler(IApartamentoRepositorio apartamentoRepositorio)
        {
            _apartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultado> Handle(DeletarApartamentoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var apartamento = _apartamentoRepositorio.Find(request.IdApartamento);
                if (apartamento is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                _apartamentoRepositorio.Delete(apartamento);

                _apartamentoRepositorio.Save();

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
