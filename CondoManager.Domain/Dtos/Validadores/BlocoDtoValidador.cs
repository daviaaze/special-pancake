using FluentValidation;

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
