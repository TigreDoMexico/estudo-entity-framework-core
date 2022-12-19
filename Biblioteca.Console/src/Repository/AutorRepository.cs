using Biblioteca.Console.Models;

namespace Biblioteca.Console.Repository;
public class AutorRepository : Repository<Autor>
{
    public Autor? BuscarPorIdViaQuery(int id)
        => (from a in dbContext.Autores where a.Id == id select a).FirstOrDefault();

    public bool Existe(int id)
        => (from a in dbContext.Autores where a.Id == id select a).Any();
}