using System;

namespace CondoManager.Domain.Dtos
{
    public class MoradorDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
