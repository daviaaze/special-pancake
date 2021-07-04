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
        List<string> Mensagens { get; set; }
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

        Exception Exception { get; set; }

        IResultado AdicionarMensagem(string mensagem);
        IResultado AdicionarMensagens(List<string> mensagens);
    }

    public interface IResultado<T> : IResultado
    {
        T Dados { get; set; }
    }

    public interface IResultadoPaginado : IResultado<IList>
    {
        int? ContagemTotal { get; set; }
        int? Paginas { get; set; }
        int Contagem { get; set; }
        int Pagina { get; set; }

        void Paginate<TSource, TResult>(IPaginacao pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction);
    }
}
