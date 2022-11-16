using Biblioteca.Console.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Service;

public abstract class Service : IDisposable
{
    private readonly string connectionString = "Server=.;Database=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True";
    protected BibliotecaDbContext _dbContext;

    public Service()
    {
        var bibliotecaDbOptions = new DbContextOptionsBuilder<BibliotecaDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        _dbContext = new BibliotecaDbContext(bibliotecaDbOptions);
    }

    public void Dispose() => _dbContext.Dispose();
}