using System;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public interface IBlocoFiltro
    {
        string Nome { get; set; }
        Guid? IdCondominio { get; set; }
    }
}
