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
    public class CriarMoradorHandler : IRequestHandler<CriarMoradorComando, IResultado>
    {

        private readonly IMoradorRepositorio _moradorRepositorio;
        private readonly IApartamentoRepositorio _apartamentoRepositorio;

        public CriarMoradorHandler(IMoradorRepositorio moradorRepositorio, IApartamentoRepositorio apartamentoRepositorio)
        {
            _moradorRepositorio = moradorRepositorio;
            _apartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultado> Handle(CriarMoradorComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new MoradorDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var apartamento = _apartamentoRepositorio.Find(request.IdApartamento);
                if(apartamento is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok).AdicionarMensagem("apartamento não encontrado"));

                var morador = new Domain.Entidades.Morador(request, apartamento);

                _moradorRepositorio.Add(morador);

                _moradorRepositorio.Save();

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
