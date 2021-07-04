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
    public class CriarApartamentoHandler : IRequestHandler<CriarApartamentoComando, IResultado>
    {

        private readonly IApartamentoRepositorio _apartamentoRepositorio;
        private readonly IBlocoRepositorio _blocoRepositorio;

        public CriarApartamentoHandler(IApartamentoRepositorio apartamentoRepositorio, IBlocoRepositorio blocoRepositorio)
        {
            _apartamentoRepositorio = apartamentoRepositorio;
            _blocoRepositorio = blocoRepositorio;
        }

        public Task<IResultado> Handle(CriarApartamentoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var valido = new ApartamentoDtoValidador().Validate(request);
                if (!valido.IsValid) return Task.FromResult(valido.ToResultado());

                var bloco = _blocoRepositorio.Find(request.IdBloco);
                if(bloco is null) return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok).AdicionarMensagem("Bloco não encontrado"));

                var apartamento = new Domain.Entidades.Apartamento(request, bloco);

                _apartamentoRepositorio.Add(apartamento);

                return Task.FromResult(Resultado.Criar(EnumTipoResultado.Ok));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado.Criar(EnumTipoResultado.ErroInterno, ex));
            }
        }
    }
}
