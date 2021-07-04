using CondoManager.Domain.Core.Interfaces;

namespace CondoManager.Domain.Core
{
    public class FiltroBase : IPaginacao
    {
        public int Pagina { get; set; }
        public bool ContarTotal { get; set; }
        public int ItensPorPagina { get; set; }
    }
}
