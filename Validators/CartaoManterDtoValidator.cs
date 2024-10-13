using FluentValidation;

namespace MeuBolsoBackend;

public class CartaoManterDtoValidator : AbstractValidator<CartaoManterDto>
{
    public CartaoManterDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Nome"))
            .MaximumLength(50).WithMessage(Message.MaxCaracteres.Bind("Nome", 50));

        RuleFor(x => x.Final)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Final"))
            .Matches(@"^\d{4}$").WithMessage(Message.CartaoFinalInvalido);
    }
}