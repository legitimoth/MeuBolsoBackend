using AutoMapper;
using System.Security.Claims;

namespace MeuBolsoBackend;

public class UsuarioService(IUsuarioRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IAuthService authService) : IUsuarioService
{
    public async Task<UsuarioDto> RecuperarPorIdAsync(long id)
    {
        var usuario = await repository.RecuperarPorIdAsync(id, false);

        return mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> AdicionarAsync()
    {
        var email = authService.RecuperarEmail();
        var usuario = await repository.RecuperarPorEmailAsync(email);

        if (usuario != null)
        {
            throw new ConflictException(Message.RegistroDuplicado.Bind("Usuário"));
        }

        usuario = new UsuarioEntity()
        {
            Nome = authService.RecuperarNome(),
            Sobrenome = authService.RecuperarSobrenome(),
            Email = email
        };

        using (var transaction = await unitOfWork.BeginTransactionAsync())
        {
            try
            {
                await repository.AdicionarAsync(usuario);
                await unitOfWork.SaveAsync();
                await authService.RegistrarUsuario(usuario.Id);
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return mapper.Map<UsuarioDto>(usuario);
    }
}
