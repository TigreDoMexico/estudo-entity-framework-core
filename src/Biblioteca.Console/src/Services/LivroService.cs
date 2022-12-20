using Biblioteca.Data.Models;
using Biblioteca.Data.Repository;
using Biblioteca.Console.UserInterface;
using Cons = System.Console;

namespace Biblioteca.Console.Service;

public class LivroService
{
    private LivroRepository repository = new LivroRepository();
    private AutorRepository autorRepository = new AutorRepository();

    public void AdicionarNovoLivro()
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

    public void ListarTodosOsLivros()
    {
        var livros = repository.BuscarTodosComAutor();
        if (livros.Count > 0)
        {
            foreach (var livro in livros)
            {
                ImprimirDadosCompletoLivro(livro);
            }
        }
        else
        {
            System.Console.WriteLine("NENHUM LIVRO ENCONTRADO");
        }
    }

    public void PesquisarLivro()
    {
        System.Console.WriteLine("Informe o Id do Livro");
        var id = UActions.ObterEntradaNumericaUsuario();

        var livroEncontrado = repository.BuscarPorIdComAutor(id);

        if (livroEncontrado is not null)
        {
            System.Console.WriteLine("LIVRO ENCONTRADO COM SUCESSO NO BANCO DE DADOS");
            ImprimirDadosCompletoLivro(livroEncontrado);
        }
        else
        {
            System.Console.WriteLine($"NENHUM LIVRO ENCONTRADO COM ID {id}");
        }
    }

    public void AtualizarLivro()
    {
        System.Console.WriteLine("Informe o Id do Livro");
        var id = UActions.ObterEntradaNumericaUsuario();

        if (repository.Existe(id))
        {
            System.Console.WriteLine("Escreva o novo nome do Livro");
            var nome = System.Console.ReadLine() ?? "";

            var livro = new Livro { Id = id };
            var dadosAlterados = new
            {
                Nome = nome
            };

            repository.Atualizar(livro, dadosAlterados);

            System.Console.WriteLine("LIVRO ALTERADO COM SUCESSO NO BANCO DE DADOS");
        }
        else
        {
            System.Console.WriteLine("NENHUM LIVRO ENCONTRADO");
        }
    }


    public void DeletarLivro()
    {
        System.Console.WriteLine("Informe o Id do Livro");
        var id = UActions.ObterEntradaNumericaUsuario();

        var livro = repository.BuscarPorId(id);

        if (livro is not null)
        {
            repository.Deletar(livro);
            System.Console.WriteLine("LIVRO REMOVIDO COM SUCESSO NO BANCO DE DADOS");
        }
        else
        {
            System.Console.WriteLine("NENHUM LIVRO ENCONTRADO");
        }
    }

    private void ImprimirDadosCompletoLivro(Livro livro)
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