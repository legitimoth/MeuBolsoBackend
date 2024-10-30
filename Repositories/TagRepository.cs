using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class TagRepository(AppDbContext context) : ITagRepository
{
    public async Task<TagEntity> AdicionarAsync(TagEntity tagEntity)
    {
        await context.Tags.AddAsync(tagEntity);

        return tagEntity;
    }

    public void Atualizar(TagEntity tagEntity)
    {
        context.Tags.Update(tagEntity);
    }

    public async Task<List<TagEntity>> RecuperarTodosPorUsuarioIdAsync(long usuarioId)
    {
        return await context.Tags.Where(t => t.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<TagEntity?> RecuperarPorIdAsync(long id)
    {
        return await context.Tags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> ExistePorNomeEUsuarioIdAsync(string nome, long usuarioId)
    {
        return await context.Tags.AnyAsync(t => t.Nome.ToUpper() == nome.ToUpper() && t.UsuarioId == usuarioId);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var tag = await context.Tags.FindAsync(id);

        if(tag != null)
        {
            context.Tags.Remove(tag);
        }
    }
}
