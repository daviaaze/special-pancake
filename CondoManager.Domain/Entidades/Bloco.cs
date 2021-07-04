using CondoManager.Domain.Core;
using System;
using System.Collections.Generic;

namespace CondoManager.Domain.Entidades
{
    public class Bloco : Entity
    {
        public string Nome { get; set; }

        public Guid IdCondominio { get; set; }
        public virtual Morador Condominio { get; set; }

        public ICollection<Apartamento> Apartamentos { get; set; }

        public void Alterar(string nome)
        {
            Nome = nome;
        }
    }
}
