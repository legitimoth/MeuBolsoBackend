namespace MeuBolsoBackend;

public class CartaoEntity
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Final { get; set; }
    public required long UsuarioId { get; set; }
}