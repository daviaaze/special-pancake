using CondoManager.Api.Core;
using CondoManager.CQS.Commands.Apartamento;
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
    public class ApartamentoController : RestController
    {
        private readonly IMediator _bus;

        public ApartamentoController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ObterApartamentoPorFiltroQuery query)
        {
            return CreateResult(await _bus.Send(query));
        }

        [HttpGet, Route("id")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new ObterApartamentoQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarApartamentoComando command)
        {
            return CreateResult(await _bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ApartamentoDto input)
        {
            return CreateResult(await _bus.Send(new AlterarApartamentoComando(id, input)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return CreateResult(await _bus.Send(new DeletarApartamentoComando(id)));
        }
    }
}
