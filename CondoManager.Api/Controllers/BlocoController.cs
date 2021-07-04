using CondoManager.Api.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Get([FromQuery] ObterBlocoPorFiltroQuery query)
        {
            return CreateResult(_bus.Send(query));
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return CreateResult(_bus.Send(new ObterBlocoQuery(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarBlocoComando command)
        {
            return CreateResult(_bus.Send(command));
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] BlocoDto input)
        {
            return CreateResult(_bus.Send(new AtualizarBlocoCommand(id, input)));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return CreateResult(_bus.Send(new DeletarBlocoCommand(id)));
        }
    }
}
