using Biblioteca.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Console.Service;

public class LivroService : Service
{
    public LivroService(string connectionString)
        : base(connectionString)
    {
    }

    public void AdicionarLivro()
    {
        var autor = _dbContext.Autores.FirstOrDefault();

        var livro = new Livro 
        {
            Autor = autor,
            Nome = "Memórias Póstumas de Brás Cubas"
        };

        _dbContext.Livros.Add(livro);
        _dbContext.SaveChanges();

        System.Console.WriteLine("LIVRO ADICIONADO COM SUCESSO");
    }

    public void ObterLivros()
    {
        var livros = _dbContext.Livros
            .Include(livro => livro.Autor)
            .ToList();

        if(livros.Count > 0)
        {
            foreach(var livro in livros)
            {
                System.Console.WriteLine($"ID: {livro.Id}");
                System.Console.WriteLine($"Nome: {livro.Nome}");

                if(livro.Autor is not null)
                {
                    System.Console.WriteLine($"Autor Id: {livro.Autor?.Id}");
                    System.Console.WriteLine($"Autor Nome: {livro.Autor?.Nome}");
                }
            }
        }
        else
        {
            System.Console.WriteLine("NENHUM LIVRO ENCONTRADO");
        }
    }
}