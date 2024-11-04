namespace MeuBolsoBackend;
public record PagamentoDto
{
    public required long Id { get; set;}
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Local { get; set; }
    public DateTimeOffset DataHora { get; set; }
    public required decimal Valor { get; set; }
    public int? Parcelas { get; set;}
    public required TipoPagamentoEntity TipoPagamento { get; set; }
    public List<TagDto> Tags { get; set; } = [];
    public bool Cancelado { get; set; } = false;
}