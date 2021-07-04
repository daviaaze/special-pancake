using CondoManager.Api.Core;
using CondoManager.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get([FromQuery] ObterApartamentoPorFiltroQuery query)
        {
            return CreateResult(_bus.Send(query));
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return CreateResult(_bus.Send(new ObterApartamentoQuery(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarApartamentoComando command)
        {
            return CreateResult(_bus.Send(command));
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] ApartamentoDto input)
        {
            return CreateResult(_bus.Send(new AtualizarApartamentoCommand(id, input)));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return CreateResult(_bus.Send(new DeletarApartamentoCommand(id)));
        }
    }
}
