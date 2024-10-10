using FluentValidation.Results;

namespace MeuBolsoBackend;

public class ModelValidationException(List<ValidationFailure> errors) :
    Exception("Ocorreram erros de validação.")
{
    public List<ValidationFailure> Errors { get; } = errors;
}
