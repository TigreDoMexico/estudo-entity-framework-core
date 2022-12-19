using Biblioteca.Console.Models;
using Biblioteca.Console.Repository;
using Biblioteca.Console.UserInterface;

namespace Biblioteca.Console.Service;

public class AutorService
{
    private AutorRepository repository = new AutorRepository();

    public void AdicionarNovoAutor()
    {
        System.Console.WriteLine("Escreva o nome do Autor");
        var nome = System.Console.ReadLine() ?? "";

        var autor = new Autor() { Nome = nome };
        repository.AdicionarNovo(autor);

        System.Console.WriteLine("AUTOR INSERIDO COM SUCESSO NO BANCO DE DADOS");
    }

    public void ObterAutor()
    {
        System.Console.WriteLine("Informe o Id do Autor");
        var id = UActions.ObterEntradaNumericaUsuario();

        var autorEncontrado = repository.BuscarPorId(id);

        if (autorEncontrado is not null)
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

    public void AtualizarAutor()
    {
        System.Console.WriteLine("Informe o Id do Autor");
        var id = UActions.ObterEntradaNumericaUsuario();

        if (repository.Existe(id))
        {
            System.Console.WriteLine("Escreva o novo nome do Autor");
            var nome = System.Console.ReadLine() ?? "";

            var autor = new Autor { Id = id };
            var dadosAlterados = new
            {
                Nome = nome
            };

            repository.Atualizar(autor, dadosAlterados);

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
        var id = UActions.ObterEntradaNumericaUsuario();

        var autor = repository.BuscarPorId(id);

        if (autor is not null)
        {
            repository.Deletar(autor);
            System.Console.WriteLine("AUTOR REMOVIDO COM SUCESSO NO BANCO DE DADOS");
        }
        else
        {
            System.Console.WriteLine("NENHUM AUTOR ENCONTRADO");
        }
    }
}