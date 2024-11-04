namespace MeuBolsoBackend;

public class TagEntity
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public virtual List<PagamentoEntity> Pagamentos { get; init; } = [];
    public long UsuarioId { get; set; }
}
