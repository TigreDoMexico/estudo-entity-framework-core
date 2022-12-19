using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Repository;
public class LivroRepository : Repository<Livro>
{
    public List<Livro> BuscarTodosComAutor() =>
        dbContext.Livros
        .Include(livro => livro.Autor)
        .ToList();
}