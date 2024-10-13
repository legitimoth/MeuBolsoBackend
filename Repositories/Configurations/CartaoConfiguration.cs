namespace MeuBolsoBackend;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TagCartaoConfiguration : IEntityTypeConfiguration<CartaoEntity>
{
    public void Configure(EntityTypeBuilder<CartaoEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Final)
            .IsRequired()
            .HasMaxLength(4)
            .IsFixedLength();

        builder.HasOne<UsuarioEntity>()
            .WithMany()
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}