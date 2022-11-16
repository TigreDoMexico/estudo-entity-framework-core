using Biblioteca.Console.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Service;

public abstract class Service : IDisposable
{
    protected BibliotecaDbContext _dbContext;

    public Service(string connectionString)
    {
        var bibliotecaDbOptions = new DbContextOptionsBuilder<BibliotecaDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        _dbContext = new BibliotecaDbContext(bibliotecaDbOptions);
    }

    public void Dispose() => _dbContext.Dispose();
}