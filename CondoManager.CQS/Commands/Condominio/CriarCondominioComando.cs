using CondoManager.Domain.Core.Interfaces;
using CondoManager.Domain.Dtos;
using MediatR;

namespace CondoManager.CQS.Commands.Condominio
{
    public class CriarCondominioComando : CondominioDto, IRequest<IResultado> 
    {
    }
}
