using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Morador
{
    public class AlterarMoradorComando : MoradorDto, IRequest<IResultado>
    {
        public AlterarMoradorComando(Guid id, MoradorDto input)
        {
            IdMorador = id;
            Cpf = input.Cpf;
            DataNascimento = input.DataNascimento;
            Email = input.Email;
            Nome = input.Nome;
            Telefone = input.Telefone;
        }

        public Guid IdMorador { get; set; }
    }
}
