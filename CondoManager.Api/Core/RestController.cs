using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CondoManager.Api.Core
{
    public abstract class RestController : ControllerBase
    {
        protected IActionResult CreateResult(IResultadoPaginado resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens,
                TotalCount = resultado.ContagemTotal,
                Count = resultado.Contagem,
                Page = resultado.Pagina,
                Pages = resultado.Paginas,
                Data = resultado.Dados
            };

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") restResult.Exception = resultado.Exception;

            return StatusCode(GetStatusCode(resultado), restResult);
        }

        protected IActionResult CreateResult<T>(IResultado<T> resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens,
                Data = resultado.Dados
            };

            return StatusCode(GetStatusCode(resultado), restResult);
        }

        protected IActionResult CreateResult(IResultado resultado)
        {
            var restResult = new RestResult
            {
                Messages = resultado.Mensagens
            };

            return StatusCode(GetStatusCode(resultado), restResult);
        }

        protected static int GetStatusCode(IResultado resultado)
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