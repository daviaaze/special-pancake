using CondoManager.Domain.Core;

namespace CondoManager.Domain.Interfaces.Filtros
{
    public class MoradorFiltro : FiltroBase
    {
        public string Nome { get; set; }
        public int Apartamento { get; set; }
        public int Andar { get; set; }
        public string NomeCondominio { get; set; }
        public string NomeBloco { get; set; }
    }
}
