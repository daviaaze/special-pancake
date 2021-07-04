using CondoManager.Domain.Entidades;
using System;

namespace CondoManager.CQS.ViewModels
{
    public class MoradorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int NumeroAndar { get; set; }
        public int NumeroApartamento { get; set; }
        public Guid IdApartamento { get; set; }

        public static implicit operator MoradorViewModel(Morador morador) => new()
        {
            Nome = morador.Nome,
            Cpf = morador.Cpf,
            DataNascimento = morador.DataNascimento,
            Email = morador.Email,
            Id = morador.Id,
            IdApartamento = morador.IdApartamento,
            NumeroAndar = morador.Apartamento.Andar,
            NumeroApartamento = morador.Apartamento.Numero,
            Telefone = morador.Telefone
        };
    }
}
