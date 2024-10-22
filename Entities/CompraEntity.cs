namespace MeuBolsoBackend;

public class CompraEntity {
    public long Id { get; set;}
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required TipoPagamentoEntity TipoPagamento { get; set; }
    public decimal Valor { get; set; }
    public int? Parcelas { get; set;}
}