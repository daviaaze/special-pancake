using CondoManager.Api.Core;
using CondoManager.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get([FromQuery] ObterCondominioPorFiltroQuery query)
        {
            return CreateResult(_bus.Send(query));
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return CreateResult(_bus.Send(new ObterCondominioQuery(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarCondominioComando command)
        {
            return CreateResult(_bus.Send(command));
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] CondominioDto input)
        {
            return CreateResult(_bus.Send(new AtualizarCondominioCommand(id, input)));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return CreateResult(_bus.Send(new DeletarCondominioCommand(id)));
        }
    }
}
