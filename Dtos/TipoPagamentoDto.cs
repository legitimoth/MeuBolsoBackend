namespace MeuBolsoBackend;

public record TipoPagamentoDto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
}