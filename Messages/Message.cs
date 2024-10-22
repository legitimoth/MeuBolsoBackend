namespace MeuBolsoBackend;

public static class Message
{
    #region Usuario
    public const string UsuarioNaoEncontrado = "Usuário não foi encontrado.";
    public const string UsuarioSemId = "Não foi possível recuperar o Id do usuário";
    public const string UsuarioSemEmail = "Não foi possível recuperar o e-mail do usuário.";
    public const string UsuarioNaoAutenticado = "Usuário não está autenticado.";
    public const string UsuarioSemPermissao = "Usuário não tem permissão para acessar este recurso.";
    #endregion

    #region Tag
    public const string TagNaoEncontrada = "Tag não foi encontrada.";
    public const string UsuarioIdNaoInformadoParaMapeamento = "O ID do usuário não foi fornecido para o mapeamento.";
    public const string TagDuplicada = "Tag já existe.";
    #endregion

    #region Cartao
    public const string CartaoFinalInvalido = "O campo Final deve conter exatamente 4 dígitos numéricos.";
    public const string CartaoDuplicado = "O cartão que você está tentando adicionar já existe.";
    #endregion

    #region Auth0
    public const string Auth0NaoConfigurado = "{0} do Auth0 não foi configurado.";
    public const string Auth0ErroAoGerarTokenApi = "Não foi possível gerar o Token da API";
    #endregion

    #region Validation
    public const string CampoObrigatorio = "{0} é obrigatório(a).";
    public const string MaxCaracteres = "{0} deve ter no máximo {1} caracteres.";
    public const string MinCaracteres = "{0} deve ter no mínimo {1} caracteres.";
    public const string CorInvalida = "A cor deve estar no formato hexadecimal, começando com '#' e contendo 3 ou 6 caracteres.";
    public const string IdMaiorQueZero = "O ID deve ser maior que zero.";
    public const string UrlInvalida = "{0} não é uma URL válida.";
    public const string RegistroDuplicado = "{0} já cadastrado.";
    #endregion

    #region Erro
    public const string ErroInesperado = "Um erro inesperado aconteceu.";
    public const string ErroParseLong = "Não foi possível converter o valor {0} para Long";
    public const string ConfiguracaoNaoEncontrada = "Não foi possível recuperar a configuração {0}";
    #endregion

    #region Generico
    public const string RecursoNaoEncontrado = "Recurso não encontrado.";
    #endregion

    /// <summary>
    /// Formata uma mensagem com os argumentos fornecidos, substituindo os placeholders
    /// dentro da mensagem pela ordem dos parâmetros.
    /// </summary>
    /// <param name="message">A mensagem original que contém placeholders, como "Usuário {0} não encontrado".</param>
    /// <param name="args">Os valores que serão substituídos nos placeholders da mensagem.</param>
    /// <returns>A mensagem formatada com os valores substituídos.</returns>
    public static string Bind(this string message, params object[] args)
    {
        return string.Format(message, args);
    }
}
