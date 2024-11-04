using FluentValidation;

namespace MeuBolsoBackend;

public class PagamentoValidator : AbstractValidator<PagamentoManterDto>
{
    public PagamentoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Nome"))
            .MaximumLength(50).WithMessage(Message.MaxCaracteres.Bind("Nome", 50));
        
        RuleFor(x => x.Descricao)
            .MaximumLength(500).WithMessage(Message.MaxCaracteres.Bind("Descrição", 500));
        
        RuleFor(x => x.Local)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Local"))
            .MaximumLength(50).WithMessage(Message.MaxCaracteres.Bind("Local", 50));
        
        RuleFor(p => p.Valor)
            .NotEmpty().WithMessage(Message.CampoObrigatorio.Bind("Valor"))
            .GreaterThan(0).WithMessage(Message.ValorMinimo.Bind("Valor", 0));
        
        RuleFor(p => p.Parcelas)
            .GreaterThan(0).WithMessage(Message.ValorMinimo.Bind("Parcelas", 0));

        RuleFor(p => p.TipoPagamentoId)
            .IsInEnum().WithMessage(Message.CampoInvalido.Bind("TipoPagamentoId"));
        
        RuleForEach(x => x.Tags).SetValidator(new TagValidator());
        
        RuleFor(p => p.CartaoId)
            .NotNull().WithMessage(Message.CartaoObrigatorio)
            .When(p => p.TipoPagamentoId == TipoPagamentoEnum.Cartao);
        
        RuleFor(p => p.CartaoId)
            .Must(cartaoId => cartaoId == null)
            .WithMessage(Message.CartaoDesnecessario)
            .When(p => p.TipoPagamentoId != TipoPagamentoEnum.Cartao);
    }
}