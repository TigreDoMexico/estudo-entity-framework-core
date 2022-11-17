using Biblioteca.Console.Configuration;
using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Context;

public class BibliotecaDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }

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