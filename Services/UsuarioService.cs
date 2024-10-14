using AutoMapper;
using System.Security.Claims;

namespace MeuBolsoBackend;

public class UsuarioService(IUsuarioRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IAuthService authService) : IUsuarioService
{
    private readonly IUsuarioRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthService _authService = authService;

    public async Task<UsuarioDto> RecuperarPorIdAsync(long id)
    {
        var usuario = await _repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.UsuarioNaoEncontrado);

        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> AdicionarAsync()
    {
        var email = _authService.RecuperarEmail();
        var usuario = await _repository.RecuperarPorEmailAsync(email);

        if (usuario != null)
        {
            throw new ConflictException(Message.RegistroDuplicado.Bind("Usuário"));
        }

        usuario = new UsuarioEntity()
        {
            Nome = _authService.RecuperarNome(),
            Sobrenome = _authService.RecuperarSobrenome(),
            Email = email
        };

        using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            try
            {
                await _repository.AdicionarAsync(usuario);
                await _unitOfWork.SaveAsync();
                await _authService.RegistrarUsuario(usuario.Id);
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return _mapper.Map<UsuarioDto>(usuario);
    }
}
