using CondoManager.Domain.Core;
using System.Collections.Generic;

namespace CondoManager.Domain.Entidades
{
    public class Condominio : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }

        public ICollection<Bloco> Blocos { get; set; }

        public void Alterar(string nome, string telefone, string emailSindico)
        {
            Nome = nome;
            Telefone = telefone;
            EmailSindico = emailSindico;
        }
    }
}
