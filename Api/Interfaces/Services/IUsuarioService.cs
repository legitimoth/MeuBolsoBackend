using System;
using MeuBolso.Api.Dtos;

namespace MeuBolso.Api.Interfaces.Services;

public interface IUsuarioService
{
    Task<UsuarioDto> AddAsync(UsuarioManterDto dto);
    Task<UsuarioDto> RecuperarPorIdAsync(long id);
}
