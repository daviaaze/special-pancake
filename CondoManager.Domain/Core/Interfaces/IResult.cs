using CondoManager.Domain.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CondoManager.Domain.Core.Interfaces
{
    public interface IResultado
    {
        EnumTipoResultado TipoResultado { get; set; }
        List<string> Mensagens { get; }
        bool Sucesso
        {
            get
            {
                return TipoResultado switch
                {
                    EnumTipoResultado.Ok or EnumTipoResultado.Criado or EnumTipoResultado.Aceito => true,
                    _ => false,
                };
            }
        }
    }

    public interface IResultado<T> : IResultado
    {
        T Data { get; set; }
    }

    public interface IResultadoPaginado : IResultado<IList>
    {
        int? TotalCount { get; set; }
        int? Pages { get; set; }
        int Count { get; set; }
        int Page { get; set; }

        void Paginate<TSource, TResult>(IPaginacao pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction);
        IResultadoPaginado AddMessage(string message);
    }
}
