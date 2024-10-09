using MeuBolso.Api.Interfaces.Services;
using MeuBolso.Api.Interfaces.Repositories;
using MeuBolso.Api.Dtos;
using MeuBolso.Api.Entities;
using AutoMapper;
using System.Security.Claims;

namespace MeuBolso.Api.Services;

public class UsuarioService(IUsuarioRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : IUsuarioService
{
    private readonly IUsuarioRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<UsuarioDto> RecuperarPorIdAsync(long id)
    {
        var usuario = await _repository.RecuperarPorIdAsync(id);

        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> AddAsync()
    {
        var usuarioInfo = _httpContextAccessor.HttpContext?.User;
        var email = (usuarioInfo?.FindFirst("emailAddress")?.Value) ?? throw new UnauthorizedAccessException("Não foi possível recuperar o e-mail do usuário.");
        var usuario = await _repository.RecuperarPorEmailAsync(email);

        if(usuario == null) {
            usuario = new UsuarioEntity()
            {
                Nome = usuarioInfo?.FindFirst("firstName")?.Value ?? "",
                Sobrenome = usuarioInfo?.FindFirst("lastName")?.Value ?? "",
                Email = email
            };
            await _repository.AddAsync(usuario);
            await _unitOfWork.SaveAsync();
        }

        return _mapper.Map<UsuarioDto>(usuario);
    }
}
