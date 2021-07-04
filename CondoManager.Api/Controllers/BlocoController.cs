using CondoManager.Api.Core;
using CondoManager.CQS.Commands.Bloco;
using CondoManager.CQS.Queries;
using CondoManager.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CondoManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocoController : RestController
    {
        private readonly IMediator _bus;

        public BlocoController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ObterBlocoPorFiltroQuery query)
        {
            return CreateResult(await _bus.Send(query));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new ObterBlocoQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarBlocoComando command)
        {
            return CreateResult(await _bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] BlocoDto input)
        {
            return CreateResult(await _bus.Send(new AlterarBlocoComando(id, input)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new DeletarBlocoComando(id)));
        }
    }
}
