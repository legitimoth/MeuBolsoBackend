namespace MeuBolsoBackend;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasOne<UsuarioEntity>()
            .WithMany()
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Define o relacionamento muitos-para-muitos com PagamentoEntity
        builder.HasMany(t => t.Pagamentos)
            .WithMany(p => p.Tags)
            .UsingEntity<Dictionary<string, object>>(
                "PagamentoTag", // Nome da tabela de junção
                j => j.HasOne<PagamentoEntity>()
                    .WithMany()
                    .HasForeignKey("PagamentoId")
                    .HasConstraintName("FK_PagamentoTag_Pagamento")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<TagEntity>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_PagamentoTag_Tag")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("PagamentoId", "TagId");
                    j.ToTable("PagamentoTag");
                });
    }
}
