using Biblioteca.Console.Models;
using Biblioteca.Console.Repository;
using Biblioteca.Console.UserInterface;
using Cons = System.Console;

namespace Biblioteca.Console.Service;

public class LivroService
{
    private LivroRepository repository = new LivroRepository();
    private AutorRepository autorRepository = new AutorRepository();

    public void AdicionarLivro()
    {
        Cons.WriteLine("Digite o nome do livro");
        var nomeLivro = Cons.ReadLine();

        if (string.IsNullOrEmpty(nomeLivro))
        {
            Cons.WriteLine("Nome do livro inválido!");
            UI.PressioneEnterParaContinuar();
            return;
        }

        var autores = autorRepository.BuscarTodos();

        Cons.WriteLine("Selecione o autor do livro");
        foreach (var autor in autores)
            Cons.WriteLine($"{autor.Id} - {autor.Nome}");

        int idAutor = UActions.ObterEntradaNumericaUsuario();
        var autorSelecionado = autores.FirstOrDefault(a => a.Id == idAutor);

        if (autorSelecionado == null)
        {
            Cons.WriteLine("Autor escolhido é inválido");
            UI.PressioneEnterParaContinuar();
            return;
        }

        var livro = new Livro
        {
            Autor = autorSelecionado,
            Nome = nomeLivro
        };

        repository.AdicionarNovo(livro);
        System.Console.WriteLine("LIVRO ADICIONADO COM SUCESSO");
    }

    public void ObterLivros()
    {
        var livros = repository.BuscarTodosComAutor();
        if (livros.Count > 0)
        {
            foreach (var livro in livros)
            {
                System.Console.WriteLine($"ID: {livro.Id}");
                System.Console.WriteLine($"Nome: {livro.Nome}");

                if (livro.Autor is not null)
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