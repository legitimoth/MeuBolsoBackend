namespace MeuBolsoBackend;

public class PagamentoEntity {
    public required long Id { get; set;}
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Local { get; set; }
    public required decimal Valor { get; set; }
    public int? Parcelas { get; set;}
    public TipoPagamentoEntity? TipoPagamento { get; set; }
    public required int TipoPagamentoId { get; set; }
    public List<TagEntity> Tags { get; set; } = [];
    public required long UsuarioId { get; set; }
    public bool Cancelado { get; set; } = false;
}