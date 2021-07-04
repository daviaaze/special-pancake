using System;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public interface IApartamentoFiltro
    {
        int? Andar { get; set; }
        Guid? IdCondominio { get; set; }
        Guid? IdBloco { get; set; }
    }
}
