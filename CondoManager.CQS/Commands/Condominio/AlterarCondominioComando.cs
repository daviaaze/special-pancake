using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;
using System;

namespace CondoManager.CQS.Commands.Condominio
{
    public class AlterarCondominioComando : CondominioDto, IRequest<IResultado>
    {
        public AlterarCondominioComando() { }
        public AlterarCondominioComando(Guid id, CondominioDto input)
        {
            IdCondominio = id;
            EmailSindico = input.EmailSindico;
            Nome = input.Nome;
            Telefone = input.Telefone;
        }

        public Guid IdCondominio { get; set; }
    }
}
