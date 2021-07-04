using FluentValidation;

namespace CondoManager.Domain.Dtos.Validadores
{
    public class ApartamentoDtoValidador : AbstractValidator<ApartamentoDto>
    {
        public ApartamentoDtoValidador()
        {
            RuleFor(d => d.Andar)
                .NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(d => d.Numero)
                .NotEmpty().ExclusiveBetween(0, int.MaxValue);
        }
    }
}
