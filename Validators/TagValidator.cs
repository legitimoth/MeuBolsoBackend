using FluentValidation;

namespace MeuBolsoBackend;

public class TagValidator : AbstractValidator<TagDto>
{
    public TagValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Nome"))
            .MaximumLength(10).WithMessage(Message.MaxCaracteres.Bind("Nome da Tag", 10));
    }
}
