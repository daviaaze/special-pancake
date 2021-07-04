using CondoManager.Api.Core;
using CondoManager.CQS.Commands.Morador;
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
    public class MoradorController : RestController
    {
        private readonly IMediator _bus;

        public MoradorController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ObterMoradorPorFiltroQuery query)
        {
            return CreateResult(await _bus.Send(query));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new ObterMoradorQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarMoradorComando command)
        {
            return CreateResult(await _bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] MoradorDto input)
        {
            return CreateResult(await _bus.Send(new AlterarMoradorComando(id, input)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new DeletarMoradorComando(id)));
        }
    }
}
