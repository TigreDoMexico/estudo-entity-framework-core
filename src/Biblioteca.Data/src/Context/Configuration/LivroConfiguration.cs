using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Context.Configuration;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livros");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasColumnType("VARCHAR(255)").IsRequired();

        builder
            .HasOne(p => p.Autor)
            .WithOne();
    }
}
