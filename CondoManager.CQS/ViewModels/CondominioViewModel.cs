using CondoManager.Domain.Entidades;
using System;

namespace CondoManager.CQS.ViewModels
{
    public class CondominioViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }
        public Guid Id { get; set; }

        public static implicit operator CondominioViewModel(Condominio condominio) => new()
        {
            Telefone = condominio.Telefone,
            EmailSindico = condominio.EmailSindico,
            Nome = condominio.Nome,
            Id = condominio.Id
        };
    }
}
