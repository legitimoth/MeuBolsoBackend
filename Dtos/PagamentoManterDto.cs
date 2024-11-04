namespace MeuBolsoBackend;

public record PagamentoManterDto
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Local { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public required decimal Valor { get; set; }
    public int? Parcelas { get; set; } = null;
    public TipoPagamentoEnum TipoPagamentoId { get; set; }
    public List<TagDto> Tags { get; set; } = [];
    public long? CartaoId { get; set; }
}