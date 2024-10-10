using FluentValidation;

namespace MeuBolsoBackend;

public class TagManterDtoValidator : AbstractValidator<TagManterDto>
{
    public TagManterDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(Message.NomeObrigatorio)
            .MaximumLength(50).WithMessage(Message.MaxCaracteres.Bind(["Nome", 50]));

        RuleFor(x => x.Cor)
            .Matches("^#([A-Fa-f0-9]{3}|[A-Fa-f0-9]{6})$")
            .When(x => !string.IsNullOrEmpty(x.Cor))
            .WithMessage(Message.CorInvalida);
    }
}
