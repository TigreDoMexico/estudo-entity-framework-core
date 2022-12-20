using Biblioteca.Data.Models;

namespace Biblioteca.Data.Repository;
public class AutorRepository : Repository<Autor>
{
    public Autor? BuscarPorIdViaQuery(int id)
        => (from a in dbContext.Autores where a.Id == id select a).FirstOrDefault();

    public bool Existe(int id)
        => (from a in dbContext.Autores where a.Id == id select a).Any();

    public bool PossuiLivrosAtreladosAoId(int id)
        => (from a in dbContext.Livros where a.Autor.Id == id select a).Any();
}