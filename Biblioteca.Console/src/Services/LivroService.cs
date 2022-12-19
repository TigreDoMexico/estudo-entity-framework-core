using Biblioteca.Console.Context;
using Biblioteca.Console.Models;
using Biblioteca.Console.UserInterface;
using Microsoft.EntityFrameworkCore;
using Cons = System.Console;

namespace Biblioteca.Console.Service;

public class LivroService
{
    public void AdicionarLivro()
    {
        Cons.Clear();

        using (var _dbContext = new BibliotecaDbContext())
        {
            Cons.WriteLine("Digite o nome do livro");
            var nomeLivro = Cons.ReadLine();

            if (string.IsNullOrEmpty(nomeLivro))
            {
                Cons.WriteLine("Nome do livro inválido!");
                UI.PressioneEnterParaContinuar();
                return;
            }

            var autores = _dbContext.Autores.ToList();

            Cons.WriteLine("Selecione o autor do livro");
            foreach (var autor in autores)
                Cons.WriteLine($"{autor.Id} - {autor.Nome}");

            int idAutor;
            var idAutorTexto = Cons.ReadLine();

            int.TryParse(idAutorTexto, out idAutor);

            if (idAutor == 0)
            {
                Cons.WriteLine("Nome do livro inválido!");
                UI.PressioneEnterParaContinuar();
                return;
            }

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

            _dbContext.Livros.Add(livro);
            _dbContext.SaveChanges();

            System.Console.WriteLine("LIVRO ADICIONADO COM SUCESSO");
        }
    }

    public void ObterLivros()
    {
        using (var _dbContext = new BibliotecaDbContext())
        {
            var livros = _dbContext.Livros
            .Include(livro => livro.Autor)
            .ToList();

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
}