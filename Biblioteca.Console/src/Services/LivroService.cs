using Biblioteca.Console.Models;

namespace Biblioteca.Console.Service;

public class LivroService : Service
{
    public void AdicionarNovoLivro()
    {
        System.Console.WriteLine("Escreva o nome do Livro");
        var nome = System.Console.ReadLine() ?? "";

        var livro = new Livro() { Nome = nome };

        _dbContext.Livros.Add(livro);
        _dbContext.SaveChanges();
    }

    public void AdicionarNovoAutor()
    {
        System.Console.WriteLine("Escreva o nome do Autor");
        var nome = System.Console.ReadLine() ?? "";

        var autor = new Autor() { Nome = nome };

        _dbContext.Autores.Add(autor);
        _dbContext.SaveChanges();

        System.Console.WriteLine("AUTOR INSERIDO COM SUCESSO NO BANCO DE DADOS");
    }

    public void ObterAutor()
    {
        System.Console.WriteLine("Informe o Id do Autor");
        var idDigitado = System.Console.ReadLine() ?? "";
        int id;
        int.TryParse(idDigitado, out id);

        var autorEncontrado = _dbContext.Autores.Where(a => a.Id == id).FirstOrDefault();
        if(autorEncontrado is not null)
        {
            System.Console.WriteLine("AUTOR ENCONTRADO COM SUCESSO NO BANCO DE DADOS");
            System.Console.WriteLine(autorEncontrado.Id);
            System.Console.WriteLine(autorEncontrado.Nome);
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }
}