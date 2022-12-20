using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Repository;
public class LivroRepository : Repository<Livro>
{
    public List<Livro> BuscarTodosComAutor() =>
        dbContext.Livros
        .Include(livro => livro.Autor)
        .ToList();

    public Livro? BuscarPorIdComAutor(int id) =>
        dbContext.Livros
        .Include(livro => livro.Autor)
        .Where(livro => livro.Id == id)
        .FirstOrDefault();

    public bool Existe(int id)
        => (from a in dbContext.Livros where a.Id == id select a).Any();
}