using MeuBolso.Api.Interfaces.Services;
using MeuBolso.Api.Interfaces.Repositories;
using MeuBolso.Api.Dtos;
using MeuBolso.Api.Entities;
using AutoMapper;

namespace MeuBolso.Api.Services;

public class UsuarioService(IUsuarioRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : IUsuarioService
{
    private readonly IUsuarioRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UsuarioDto> RecuperarPorIdAsync(long id)
    {
        var usuario = await _repository.RecuperarPorIdAsync(id);

        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> AddAsync(UsuarioManterDto dto)
    {
        var usuario = await _repository.RecuperarPorEmailAsync(dto.Email);

        if(usuario == null) {
            usuario = _mapper.Map<UsuarioEntity>(dto);
            await _repository.AddAsync(usuario);
            await _unitOfWork.SaveAsync();
        }

        return _mapper.Map<UsuarioDto>(usuario);
    }
}
