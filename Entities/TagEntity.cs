namespace MeuBolsoBackend;

public class TagEntity
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public string? Cor { get; set; }
    public required long UsuarioId { get; set; }
}
