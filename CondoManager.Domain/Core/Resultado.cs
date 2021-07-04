using CondoManager.Domain.Core.Enums;
using CondoManager.Domain.Core.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CondoManager.Domain.Core
{
    public class Resultado : IResultado
    {
        public EnumTipoResultado TipoResultado { get; set; }

        public List<string> Mensagens { get; set; }
        public Exception Exception { get; set; }

        public IResultado AdicionarMensagem(string mensagem)
        {
            if (Mensagens is null) Mensagens = new List<string>();
            Mensagens.Add(mensagem);

            return this;
        }

        public IResultado AdicionarMensagens(List<string> mensagens)
        {
            if (Mensagens is null) Mensagens = new List<string>();
            mensagens.ForEach(mensagem => Mensagens.Add(mensagem));

            return this;
        }

        public static IResultado Criar(EnumTipoResultado tipoResultado)
        {
            return new Resultado()
            {
                TipoResultado = tipoResultado
            };
        }

        public static IResultado Criar(EnumTipoResultado tipoResultado, string mensagem)
        {
            return new Resultado()
            {
                TipoResultado = tipoResultado,
                Mensagens = new List<string> { mensagem }
            };
        }

        public static IResultado Criar(EnumTipoResultado tipoResultado, Exception exception)
        {
            return new Resultado()
            {
                TipoResultado = tipoResultado,
                Exception = exception
            };
        }
    }

    public class Resultado<T> : Resultado, IResultado<T>
    {
        public T Dados { get; set; }

        public static IResultado<T> Criar(EnumTipoResultado tipoResultado, T data)
        {
            return new Resultado<T>()
            {
                TipoResultado = tipoResultado,
                Dados = data
            };
        }

        public new static IResultado<T> Criar(EnumTipoResultado tipoResultado, Exception ex)
        {
            return new Resultado<T>()
            {
                TipoResultado = tipoResultado,
                Exception = ex
            };
        }

        public new static IResultado<T> Criar(EnumTipoResultado tipoResultado, string mensagem)
        {
            return new Resultado<T>()
            {
                TipoResultado = tipoResultado,
                Mensagens = new List<string> { mensagem }
            };
        }

        public new static IResultado<T> Criar(EnumTipoResultado tipoResultado)
        {
            return new Resultado<T>()
            {
                TipoResultado = tipoResultado
            };
        }
    }

    public class ResultadoPaginado : Resultado, IResultadoPaginado
    {
        public int? ContagemTotal { get; set; }
        public int? Paginas { get; set; }
        public int Contagem { get; set; }
        public int Pagina { get; set; }
        public IList Dados { get; set; }

        public void Paginate<TSource, TResult>(IPaginacao pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
        {
            Pagina = pagination.Pagina == 0 ? 1 : pagination.Pagina;

            if (pagination.ContarTotal && Pagina == 1)
            {
                ContagemTotal = source.Count();

                double pages = ContagemTotal.Value / (double)pagination.ItensPorPagina;

                Paginas = (int)(pages % 1 == 0 ? pages : pages + 1);
            }

            var paginatedSource = source.Skip(Pagina * pagination.ItensPorPagina - pagination.ItensPorPagina).Take(pagination.ItensPorPagina);


            var registrosSelecionados = paginatedSource.Select(selectFunction);
            Dados = registrosSelecionados.ToList();
            Contagem = Dados.Count;
        }

        public new static IResultadoPaginado Criar(EnumTipoResultado tipoResultado)
        {
            return new ResultadoPaginado()
            {
                TipoResultado = tipoResultado
            };
        }

        public new static IResultadoPaginado Criar(EnumTipoResultado tipoResultado, Exception ex)
        {
            return new ResultadoPaginado()
            {
                TipoResultado = tipoResultado,
                Exception = ex
            };
        }

        public static IResultadoPaginado CriarSucesso<TSource, TResult>(IPaginacao pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
        {
            var retorno = new ResultadoPaginado
            {
                TipoResultado = EnumTipoResultado.Ok
            };
            retorno.Paginate(pagination, source, selectFunction);
            return retorno;
        }
    }

    public static class ResultadoUtils
    {

        public static IResultado ToResultado(this ValidationResult validation)
        {
            return Resultado.Criar(EnumTipoResultado.InputInvalido).AdicionarMensagens(validation.Errors.Select(d => d.ErrorMessage).ToList());
        }
    }
}
