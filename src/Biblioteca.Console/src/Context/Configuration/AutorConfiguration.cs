using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Console.src.Context.Configuration;

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autores");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasColumnType("VARCHAR(255)").IsRequired();
    }
}
