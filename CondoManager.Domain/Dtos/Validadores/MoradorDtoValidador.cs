using FluentValidation;
using System;

namespace CondoManager.Domain.Dtos.Validadores
{
    public class MoradorDtoValidador : AbstractValidator<MoradorDto>
    {
        public MoradorDtoValidador()
        {
            RuleFor(d => d.Cpf)
                .NotEmpty().Matches("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}");
            RuleFor(d => d.DataNascimento)
                .NotEmpty();
            RuleFor(d => d.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Morador deve ser maior de 18 anos");
            RuleFor(d => d.Email)
                .NotEmpty().EmailAddress();
            RuleFor(d => d.Nome)
                .NotEmpty();
            RuleFor(d => d.Telefone)
                .NotEmpty().Length(10, 11);
        }
    }
}
