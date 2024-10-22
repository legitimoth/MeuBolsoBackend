namespace MeuBolsoBackend;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TipoPagamentoConfiguration : IEntityTypeConfiguration<TipoPagamentoEntity>
{
    public void Configure(EntityTypeBuilder<TipoPagamentoEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .IsRequired()
            .HasMaxLength(50);
    }
}