using CondoManager.Domain.Core;
using System;
using System.Collections.Generic;

namespace CondoManager.Domain.Entidades
{
    public class Apartamento : Entity
    {
        public int Numero { get; set; }
        public int Andar { get; set; }

        public Guid IdBloco { get; set; }
        public virtual Bloco Bloco { get; set; }

        public virtual ICollection<Morador> Moradores { get; set; }

        public void Alterar(int numero, int andar)
        {
            Numero = numero;
            Andar = andar;
        }
    }
}
