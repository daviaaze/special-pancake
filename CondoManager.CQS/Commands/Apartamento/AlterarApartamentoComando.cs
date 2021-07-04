using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Apartamento
{
    public class AlterarApartamentoComando : ApartamentoDto, IRequest<IResultado>
    {
        public AlterarApartamentoComando() { }
        public AlterarApartamentoComando(Guid id, ApartamentoDto input)
        {
            IdApartamento = id;
            Andar = input.Andar;
            Numero = input.Numero;
        }

        public Guid IdApartamento { get; set; }
    }
}
