namespace MeuBolsoBackend;

using FluentValidation;
public class Auth0SettingsValidator : AbstractValidator<Auth0Settings>
{
    public Auth0SettingsValidator()
    {
        // Validação para o domínio
        RuleFor(x => x.Domain)
            .NotEmpty().WithMessage(Message.Auth0NaoConfigurado.Bind("Domínio"))
            .Must(domain => Uri.IsWellFormedUriString(domain, UriKind.Absolute))
            .WithMessage(x => Message.UrlInvalida.Bind(x.Domain));

        // Validação para as propriedades da ApiSettings
        RuleFor(x => x.Api)
            .NotNull().WithMessage(Message.Auth0NaoConfigurado.Bind("Api"))
            .SetValidator(new Auth0ApiSettingsValidator());

        // Validação para as propriedades da M2MSettings
        RuleFor(x => x.M2M)
            .NotNull().WithMessage(Message.Auth0NaoConfigurado.Bind("M2M"))
            .SetValidator(new Auth0M2MSettingsValidator());
    }
}

// Validador para a classe ApiSettings
public class Auth0ApiSettingsValidator : AbstractValidator<Auth0ApiSettings>
{
    public Auth0ApiSettingsValidator()
    {
        RuleFor(x => x.Audience)
            .NotEmpty().WithMessage(Message.Auth0NaoConfigurado.Bind("Api Audience"));
    }
}

public class Auth0AppSettingsValidator : AbstractValidator<Auth0AppSettings>
{
    public Auth0AppSettingsValidator()
    {
        RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage(Message.Auth0NaoConfigurado.Bind("Application ClientId"));
    }
}


// Validador para a classe M2MSettings
public class Auth0M2MSettingsValidator : AbstractValidator<Auth0M2MSettings>
{
    public Auth0M2MSettingsValidator()
    {
        RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage(Message.Auth0NaoConfigurado.Bind("M2M ClientId"));

        RuleFor(x => x.ClientSecret)
            .NotEmpty().WithMessage(Message.Auth0NaoConfigurado.Bind("M2M ClientSecret"));
    }
}