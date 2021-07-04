namespace CondoManager.Domain.Core.Interfaces
{
    public interface IPaginacao
    {
        public int Pagina { get; set; }
        public bool ContarTotal { get; set; }
        public int ItensPorPagina { get; set; }
    }
}
