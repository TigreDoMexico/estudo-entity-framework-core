using Biblioteca.Console.Context;

namespace Biblioteca.Console.Service;

public abstract class Service : IDisposable
{
    protected BibliotecaDbContext _dbContext;

    public Service()
    {
        _dbContext = new BibliotecaDbContext();
    }

    public Service(string connectionString)
    {
        _dbContext = new BibliotecaDbContext(connectionString);
    }

    public void Dispose() => _dbContext.Dispose();
}