using CondoManager.Domain.Entidades;
using System;

namespace CondoManager.CQS.ViewModels
{
    public class ApartamentoViewModel
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int Andar { get; set; }
        public Guid IdBloco { get; set; }
        public string NomeBloco { get; set; }

        public static implicit operator ApartamentoViewModel(Apartamento apartamento) => new()
        {
            Id = apartamento.Id,
            Andar = apartamento.Andar,
            IdBloco = apartamento.IdBloco,
            NomeBloco = apartamento.Bloco.Nome,
            Numero = apartamento.Numero
        };
    }
}
