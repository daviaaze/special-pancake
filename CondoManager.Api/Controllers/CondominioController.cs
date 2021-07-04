using CondoManager.Api.Core;
using CondoManager.CQS.Commands.Condominio;
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
    public class CondominioController : RestController
    {
        private readonly IMediator _bus;

        public CondominioController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ObterCondominioPorFiltroQuery query)
        {
            return CreateResult(await _bus.Send(query));
        }

        [HttpGet, Route("id")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new ObterCondominioQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCondominioComando command)
        {
            return CreateResult(await _bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] CondominioDto input)
        {
            return CreateResult(await _bus.Send(new AlterarCondominioComando(id, input)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CreateResult(await _bus.Send(new DeletarCondominioComando(id)));
        }
    }
}
