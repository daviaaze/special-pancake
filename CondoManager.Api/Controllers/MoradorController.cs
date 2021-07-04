using CondoManager.Api.Core;
using CondoManager.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get([FromQuery] ObterMoradorPorFiltroQuery query)
        {
            return CreateResult(_bus.Send(query));
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return CreateResult(_bus.Send(new ObterMoradorQuery(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarMoradorComando command)
        {
            return CreateResult(_bus.Send(command));
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] MoradorDto input)
        {
            return CreateResult(_bus.Send(new AtualizarMoradorCommand(id, input)));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return CreateResult(_bus.Send(new DeletarMoradorCommand(id)));
        }
    }
}
