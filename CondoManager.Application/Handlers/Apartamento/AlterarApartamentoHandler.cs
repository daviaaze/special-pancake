using CondoManager.CQS.Commands.Apartamento;
using CondoManager.Domain.Core;
using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos.Validadores;
using CondoManager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CondoManager.Application.Handlers.Apartamento
{
    public class AlterarApartamentoHandler : IRequestHandler<AlterarApartamentoComando, IResultado>
    {

        private readonly IApartamentoRepositorio _apartamentoRepositorio;

        public AlterarApartamentoHandler(IApartamentoRepositorio apartamentoRepositorio)
        {
            _apartamentoRepositorio = apartamentoRepositorio;
        }

        public Task<IResultado> Handle(AlterarApartamentoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new ApartamentoDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var apartamento = _apartamentoRepositorio.Find(request.IdApartamento);
                if (apartamento is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.NaoEncontrado));

                apartamento.Alterar(request);

                _apartamentoRepositorio.Update(apartamento);

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
