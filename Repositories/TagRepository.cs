using Microsoft.EntityFrameworkCore;

namespace MeuBolsoBackend;

public class TagRepository : ITagRepository
{

    private readonly long _usuarioId;
    private readonly DbSet<TagEntity> _context;

    public TagRepository(AppDbContext context, IAuthService authService)
    {
        _usuarioId = authService.RecuperarId();
        _context = context.Tags;
    }

    public async Task AdicionarAsync(List<TagEntity> tagsEntity)
    {
        tagsEntity.ForEach(t => t.UsuarioId = _usuarioId);
        await _context.AddRangeAsync(tagsEntity);
    }

    public async Task<List<TagEntity>> RecuperarTodosAsync()
    {
        return await _context.Where(t => t.UsuarioId.Equals(_usuarioId))
            .ToListAsync();
    }
    
    public async Task<List<TagEntity>> RecuperarPorNomesAsync(List<string> nomes)
    {
        return await _context.Where(t => 
            nomes.Select(n => n.ToUpper()).Contains(t.Nome.ToUpper()) && 
            t.UsuarioId.Equals(_usuarioId)
        )
        .ToListAsync();
    }

    public async Task<bool> VerificarDuplicidade(string nome)
    {
        return await _context.AnyAsync(t => 
            t.Nome.ToUpper().Equals(nome.ToUpper()) && 
            t.UsuarioId.Equals(_usuarioId)
        );
    }

    public void Remover(List<TagEntity> tagsEntity)
    {
        _context.RemoveRange(tagsEntity);
    }
}
