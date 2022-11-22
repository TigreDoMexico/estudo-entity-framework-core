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
            var opcao = ObterOpcaoUsuario();

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
        bool voltar = false;
        Cons.Clear();

        while (!voltar)
        {
            UI.ImprimirMenuLivros();
            var opcao = ObterOpcaoUsuario();

            switch (opcao)
            {
                case (int)LivrosActions.Adicionar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)LivrosActions.Listar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)LivrosActions.Pesquisar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)LivrosActions.Atualizar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)LivrosActions.Remover:
                    // AÇÃO DO USUÁRIO
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
        bool voltar = false;
        Cons.Clear();

        while (!voltar)
        {
            UI.ImprimirMenuAutores();
            var opcao = ObterOpcaoUsuario();

            switch (opcao)
            {
                case (int)AutoresActions.Adicionar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)AutoresActions.Listar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)AutoresActions.Pesquisar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)AutoresActions.Atualizar:
                    // AÇÃO DO USUÁRIO
                    break;
                case (int)AutoresActions.Remover:
                    // AÇÃO DO USUÁRIO
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

    public static int ObterOpcaoUsuario()
    {
        int opcao;
        var opcaoTexto = Cons.ReadLine();

        int.TryParse(opcaoTexto, out opcao);

        return opcao;
    }
}