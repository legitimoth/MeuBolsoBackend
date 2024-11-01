namespace MeuBolsoBackend;

public record PagamentoAtualizarDto
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Local { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public required decimal Valor { get; set; }
    public int? Parcelas { get; set;}
    public TipoPagamentoEnum TipoPagamentoId { get; set; }
}