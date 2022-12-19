using Biblioteca.Console.Service;
using Biblioteca.Console.UserInterface.Actions;
using Cons = System.Console;

namespace Biblioteca.Console.UserInterface;

public static class UActions
{
    public static void MenuPrincipal()
    {
        bool fimPrograma = false;

        while (!fimPrograma)
        {
            UI.ImprimirMenuPrincipal();
            var opcao = ObterEntradaNumericaUsuario();

            switch (opcao)
            {
                case (int)MenuActions.Autores:
                    MenuAutores();
                    break;
                case (int)MenuActions.Livros:
                    MenuLivros();
                    break;
                case (int)MenuActions.Sair:
                    UI.ImprimirDespedida();
                    fimPrograma = true;
                    break;
                default:
                    UI.OpcaoInvalida();
                    break;
            }
        }
    }

    public static void MenuLivros()
    {
        var service = new LivroService();

        bool voltar = false;
        Cons.Clear();

        while (!voltar)
        {
            UI.ImprimirMenuLivros();
            var opcao = ObterEntradaNumericaUsuario();

            switch (opcao)
            {
                case (int)LivrosActions.Adicionar:
                    service.AdicionarNovoLivro();
                    break;
                case (int)LivrosActions.Listar:
                    service.ListarTodosOsLivros();
                    break;
                case (int)LivrosActions.Pesquisar:
                    service.PesquisarLivro();
                    break;
                case (int)LivrosActions.Atualizar:
                    service.AtualizarLivro();
                    break;
                case (int)LivrosActions.Remover:
                    service.DeletarLivro();
                    break;
                case (int)LivrosActions.Voltar:
                    voltar = true;
                    break;
                default:
                    UI.OpcaoInvalida();
                    break;
            }

            Cons.Clear();
        }
    }

    public static void MenuAutores()
    {
        var service = new AutorService();

        bool voltar = false;
        Cons.Clear();

        while (!voltar)
        {
            UI.ImprimirMenuAutores();
            var opcao = ObterEntradaNumericaUsuario();

            switch (opcao)
            {
                case (int)AutoresActions.Adicionar:
                    service.AdicionarNovoAutor();
                    break;
                case (int)AutoresActions.Listar:
                    service.ListaTodosOsAutores();
                    break;
                case (int)AutoresActions.Pesquisar:
                    service.PesquisarAutor();
                    break;
                case (int)AutoresActions.Atualizar:
                    service.AtualizarAutor();
                    break;
                case (int)AutoresActions.Remover:
                    service.DeletarAutor();
                    break;
                case (int)AutoresActions.Voltar:
                    voltar = true;
                    break;
                default:
                    UI.OpcaoInvalida();
                    break;
            }

            Cons.Clear();
        }
    }

    public static int ObterEntradaNumericaUsuario()
    {
        int opcao = -1;

        while(opcao == -1) {
            var opcaoTexto = Cons.ReadLine();
            int.TryParse(opcaoTexto, out opcao);

            if(opcao == -1)
                Cons.WriteLine("Favor digitar uma entrada numérica válida");
        }

        Cons.Clear();
        return opcao;
    }
}