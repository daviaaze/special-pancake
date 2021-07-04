using CondoManager.Domain.Core;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public class ApartamentoFiltro : FiltroBase
    {
        public int Apartamneto { get; set; }
        public int Andar { get; set; }
        public string NomeCondominio { get; set; }
        public string NomeBloco { get; set; }
    }
}
