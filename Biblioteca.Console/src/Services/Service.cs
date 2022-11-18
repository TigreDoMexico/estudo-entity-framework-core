using Biblioteca.Console.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Service;

public abstract class Service : IDisposable
{
    protected BibliotecaMariaDbContext _dbContext;

    public Service(string connectionString)
    {
        _dbContext = new BibliotecaMariaDbContext(connectionString);
    }

    public void Dispose() => _dbContext.Dispose();
}