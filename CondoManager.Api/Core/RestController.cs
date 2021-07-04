using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondoManager.Api.Core
{
    public class RestController : ControllerBase
    {
        public IActionResult CreateResult(IResultado resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens
            };

            return StatusCode(GetStatusCode(resultado), restResult);
        }

        public IActionResult CreateResult(IResultado<object> resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens,
                Data = resultado.Data
            };

            return StatusCode(GetStatusCode(resultado), restResult);
        }

        public IActionResult CreateResult(IResultadoPaginado resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens,
                TotalCount = resultado.TotalCount,
                Count = resultado.Count,
                Page = resultado.Page,
                Pages = resultado.Pages,
                Data = resultado.Data
            };


            return StatusCode(GetStatusCode(resultado), restResult);
        }

        private static int GetStatusCode(IResultado resultado)
        {
            return resultado.TipoResultado switch
            {
                EnumTipoResultado.Ok => 200,
                EnumTipoResultado.Criado => 201,
                EnumTipoResultado.Aceito => 202,
                EnumTipoResultado.InputInvalido => 400,
                EnumTipoResultado.NaoEncontrado => 404,
                EnumTipoResultado.Proibido => 403,
                EnumTipoResultado.ErroInterno => 500,
                EnumTipoResultado.ServicoIndisponivel => 503,
                _ => 200,
            };
        }
    }
}