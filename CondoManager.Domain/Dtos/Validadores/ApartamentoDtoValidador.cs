using FluentValidation;

namespace CondoManager.Domain.Dtos.Validadores
{
    public class ApartamentoDtoValidador : AbstractValidator<ApartamentoDto>
    {
        public ApartamentoDtoValidador()
        {
            RuleFor(d => d.Andar)
                .NotEmpty().ExclusiveBetween(int.MinValue, int.MaxValue);
            RuleFor(d => d.Numero)
                .NotEmpty().ExclusiveBetween(int.MinValue, int.MaxValue);
        }
    }
}
