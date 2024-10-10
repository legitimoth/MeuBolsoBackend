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
            .HasMaxLength(50);

        builder.Property(t => t.Cor)
            .HasMaxLength(7);

        builder.HasOne<UsuarioEntity>()
            .WithMany()
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
