using Biblioteca.Console.Models;

namespace Biblioteca.Console.Service;

public class LivroService : Service
{
    public LivroService(string connectionString) : base(connectionString)
    {
    }

    public void AdicionarNovoAutor()
    {
        System.Console.WriteLine("Escreva o nome do Autor");
        var nome = System.Console.ReadLine() ?? "";

        var autor = new Autor() { Nome = nome };

        _dbContext.Autores.Add(autor);
        // _dbContext.Set<Autor>().Add(autor);
        // _dbContext.Entry(autor).State = EntityState.Added;

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
            System.Console.WriteLine($"Id: {autorEncontrado.Id}");
            System.Console.WriteLine($"Nome: {autorEncontrado.Nome}");
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }
}