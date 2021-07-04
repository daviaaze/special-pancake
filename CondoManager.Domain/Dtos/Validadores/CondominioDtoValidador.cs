using FluentValidation;

namespace CondoManager.Domain.Dtos.Validadores
{
    public class CondominioDtoValidador : AbstractValidator<CondominioDto>
    {
        public CondominioDtoValidador()
        {
            RuleFor(d => d.Nome)
                .NotEmpty();
            RuleFor(d => d.Telefone)
                .NotEmpty().Length(10, 11);
            RuleFor(d => d.EmailSindico)
                .NotEmpty().EmailAddress();
        }
    }
}
