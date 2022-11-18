using Biblioteca.Console.Configuration;
using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Context;

public class BibliotecaMariaDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }

    public BibliotecaMariaDbContext()
    {
        _connectionString = EnvironmentVariableConfig
            .GetEnvironmentVariable()
            .GetMariaDbConnectionString();
    }

    public BibliotecaMariaDbContext(string connectionString) =>
        _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseMySQL(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaMariaDbContext).Assembly);
    }
}