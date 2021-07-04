using System;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public interface IMoradorFiltro
    {
        string Nome { get; set; }
        Guid? IdApartamento { get; set; }
        int? Andar { get; set; }
        Guid? IdCondominio { get; set; }
        Guid? IdBloco { get; set; }
    }
}
