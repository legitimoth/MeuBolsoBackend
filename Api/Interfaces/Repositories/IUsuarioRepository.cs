using System;
using MeuBolso.Api.Entities;

namespace MeuBolso.Api.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> AddAsync(UsuarioEntity usuario);
    Task<UsuarioEntity?> RecuperarPorEmailAsync(string email);
    Task<UsuarioEntity?> RecuperarPorIdAsync(long id);
}
