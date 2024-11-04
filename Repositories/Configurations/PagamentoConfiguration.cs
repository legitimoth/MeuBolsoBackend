namespace MeuBolsoBackend;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PagamentoConfiguration : IEntityTypeConfiguration<PagamentoEntity>
{
    public void Configure(EntityTypeBuilder<PagamentoEntity> builder)
    {
        // Definindo a chave primária
        builder.HasKey(p => p.Id);

        // Configurando propriedades requeridas
        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50); // Opcional: definir um tamanho máximo

        builder.Property(p => p.Valor)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); // Definindo precisão e escala

        builder.Property(p => p.UsuarioId)
            .IsRequired();

        // Configurando propriedades opcionais
        builder.Property(p => p.Descricao)
            .HasMaxLength(500); // Opcional: definir um tamanho máximo

        builder.Property(p => p.Local)
            .HasMaxLength(50); // Opcional: definir um tamanho máximo

        builder.Property(p => p.DataHora)
            .IsRequired();

        builder.Property(p => p.Parcelas);

        // Configurando a propriedade Cancelado com valor padrão
        builder.Property(p => p.Cancelado)
            .HasDefaultValue(false);

        builder.Property(p => p.TipoPagamentoId)
            .IsRequired();
        
        // Configurando o relacionamento com TipoPagamentoEntity
        builder.HasOne(p => p.TipoPagamento)
            .WithMany() // Presumindo que TipoPagamentoEntity não tem uma coleção de Pagamentos
            .HasForeignKey(p => p.TipoPagamentoId)
            .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata

        // Configurando o relacionamento muitos-para-muitos com TagEntity
        builder.HasMany(p => p.Tags)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PagamentoTag", // Nome da tabela de junção
                j => j.HasOne<TagEntity>()
                      .WithMany()
                      .HasForeignKey("TagId")
                      .HasConstraintName("FK_PagamentoTag_Tag")
                      .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<PagamentoEntity>()
                      .WithMany()
                      .HasForeignKey("PagamentoId")
                      .HasConstraintName("FK_PagamentoTag_Pagamento")
                      .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("PagamentoId", "TagId");
                    j.ToTable("PagamentoTag");
                });
        
        builder.Property(p => p.CartaoId)
            .IsRequired();
        
        // Configurando o relacionamento com Cartao
        builder.HasOne(p => p.Cartao)
            .WithMany() // Presumindo que Cartão não tem uma coleção de Pagamentos
            .HasForeignKey(p => p.CartaoId)
            .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
        
    }
}