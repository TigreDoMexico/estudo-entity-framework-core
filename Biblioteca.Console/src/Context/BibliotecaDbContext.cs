using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Context;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }
}