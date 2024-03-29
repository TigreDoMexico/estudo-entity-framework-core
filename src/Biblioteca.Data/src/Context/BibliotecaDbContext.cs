using Biblioteca.Data.Configuration;
using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Context;

internal class BibliotecaDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Autor> Autores { get; set; } = default!;
    public DbSet<Livro> Livros { get; set; } = default!;

    public BibliotecaDbContext()
    {
        _connectionString = EnvironmentVariableConfig
            .GetEnvironmentVariable()
            .GetSqlServerConnectionString();
    }

    public BibliotecaDbContext(string connectionString) =>
        _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaDbContext).Assembly);
    }
}