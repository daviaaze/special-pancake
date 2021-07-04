using CondoManager.Domain.Entidades;
using System;

namespace CondoManager.CQS.ViewModels
{
    public class BlocoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCondominio { get; set; }
        public Guid IdCondominio { get; set; }

        public static implicit operator BlocoViewModel(Bloco bloco) => new()
        {
            Id = bloco.Id,
            IdCondominio = bloco.IdCondominio,
            Nome = bloco.Nome,
            NomeCondominio = bloco.Condominio.Nome
        };
    }
}
