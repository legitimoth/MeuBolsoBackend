using System;
using MeuBolso.Api.Entities;
using MeuBolso.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    private readonly AppDbContext _context = context;

    public async Task<UsuarioEntity> AddAsync(UsuarioEntity usuario)
    {
        await _context.AddAsync(usuario);

        return usuario;
    }

    public async Task<UsuarioEntity?> RecuperarPorIdAsync(long id) {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<UsuarioEntity?> RecuperarPorEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}
