using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoManager.Domain.Dtos.Validadores
{
    public class BlocoDtoValidador : AbstractValidator<BlocoDto>
    {
        public BlocoDtoValidador()
        {
            RuleFor(d => d.Nome)
                .NotEmpty();
        }
    }
}
