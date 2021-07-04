using CondoManager.Domain.Core;
using CondoManager.Domain.Dtos;
using System;

namespace CondoManager.Domain.Entidades
{
    public class Morador : Entity
    {
        protected Morador() { }

        public Morador(MoradorDto dto, Apartamento apartamento)
        {
            Nome = dto.Nome;
            DataNascimento = dto.DataNascimento;
            Telefone = dto.Telefone;
            Cpf = dto.Cpf;
            Email = dto.Email;
            Apartamento = apartamento;
        }

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

        public void Alterar(MoradorDto dto)
        {
            Nome = dto.Nome;
            DataNascimento = dto.DataNascimento;
            Telefone = dto.Telefone;
            Cpf = dto.Cpf;
            Email = dto.Email;
        }
    }
}
