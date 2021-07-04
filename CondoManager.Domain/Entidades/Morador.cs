using CondoManager.Domain.Core;
using System;

namespace CondoManager.Domain.Entidades
{
    public class Morador : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public Guid IdApartamento { get; set; }
        public virtual Apartamento Apartamento { get; set; }

        public void Alterar(string nome, DateTime dataNascimento, string telefone, string cpf, string email)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Cpf = cpf;
            Email = email;
        }
    }
}
