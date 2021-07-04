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

        private readonly IApartamentoRepositorio _ApartamentoRepositorio;

        public DeletarApartamentoHandler(IApartamentoRepositorio apartamentoRepositorio)
        {
            _ApartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultado> Handle(DeletarApartamentoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var Apartamento = _ApartamentoRepositorio.Find(request.IdApartamento);
                if (Apartamento is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                _ApartamentoRepositorio.Delete(Apartamento);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
