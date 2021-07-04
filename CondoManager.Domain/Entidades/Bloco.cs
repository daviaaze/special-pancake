using CondoManager.Domain.Core;
using CondoManager.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace CondoManager.Domain.Entidades
{
    public class Bloco : Entity
    {
        protected Bloco() { }
        public Bloco(BlocoDto dto, Condominio condominio)
        {
            Nome = dto.Nome;
            Condominio = condominio;
        }

        public string Nome { get; set; }

        public Guid IdCondominio { get; set; }
        public virtual Condominio Condominio { get; set; }

        public ICollection<Apartamento> Apartamentos { get; set; }

        public void Alterar(string nome)
        {
            Nome = nome;
        }

        public void Alterar(BlocoDto dto)
        {
            Nome = dto.Nome;
        }
    }
}
