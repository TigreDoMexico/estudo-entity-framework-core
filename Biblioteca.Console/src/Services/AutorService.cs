using Biblioteca.Console.Models;

namespace Biblioteca.Console.Service;

public class AutorService : Service
{
    public AutorService(string connectionString)
        : base(connectionString)
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

        // var autorPorQuery = (from a in _dbContext.Autores where a.Id == id select a).FirstOrDefault();
        var autorPorMetodo = _dbContext.Autores.Find(id);

        if(autorPorMetodo is not null)
        {
            System.Console.WriteLine("AUTOR ENCONTRADO COM SUCESSO NO BANCO DE DADOS");
            System.Console.WriteLine($"Id: {autorPorMetodo.Id}");
            System.Console.WriteLine($"Nome: {autorPorMetodo.Nome}");
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }

    public void AtualizarAutor()
    {
        System.Console.WriteLine("Informe o Id do Autor");
        var idDigitado = System.Console.ReadLine() ?? "";
        int id;
        int.TryParse(idDigitado, out id);

        var existeAutor = (from a in _dbContext.Autores where a.Id == id select a).Any();

        if(existeAutor)
        {
            System.Console.WriteLine("Escreva o novo nome do Autor");
            var nome = System.Console.ReadLine() ?? "";

            var autor = new Autor { Id = id };
            var dadosAlterados = new
            {
                Nome = nome
            };

            _dbContext.Autores.Attach(autor);
            _dbContext.Entry(autor).CurrentValues.SetValues(dadosAlterados);

            _dbContext.SaveChanges();

            System.Console.WriteLine("AUTOR ALTERADO COM SUCESSO NO BANCO DE DADOS");
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }

    public void DeletarAutor()
    {
        System.Console.WriteLine("Informe o Id do Autor");
        var idDigitado = System.Console.ReadLine() ?? "";
        int id;
        int.TryParse(idDigitado, out id);

        var autor = _dbContext.Autores.Find(id);

        if(autor is not null)
        {
            _dbContext.Autores.Remove(autor);
            _dbContext.SaveChanges();

            System.Console.WriteLine("AUTOR REMOVIDO COM SUCESSO NO BANCO DE DADOS");
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }
}