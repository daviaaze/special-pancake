using CondoManager.Domain.Core;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public class BlocoFiltro : FiltroBase
    {
        public string Nome { get; set; }
        public string NomeCondominio { get; set; }
    }
}
