using Cons = System.Console;

namespace Biblioteca.Console.UserInterface;

public static class UI
{
    public static void ImprimirBoasVindas()
        => Cons.WriteLine("BEM VINDO AO SISTEMA DE BIBLIOTECA!");

    public static void ImprimirDespedida()
    {
        Cons.Clear();
        Cons.WriteLine("OBRIGADO POR USAR O SISTEMA!");
        Cons.WriteLine();
        Cons.WriteLine("PRESSIONE ENTER PARA FINALIZAR");
        Cons.ReadLine();
    }

    public static void ImprimirMenuPrincipal()
    {
        Cons.WriteLine("=== ESCOLHA UMA OPÇÃO ===");
        Cons.WriteLine("=== 1 - LIVRO ===");
        Cons.WriteLine("=== 2 - AUTOR ===");
    }

    public static void ImprimirMenuLivros()
    {
        Cons.WriteLine("=== O QUE VOCÊ DESEJA FAZER EM LIVROS ===");
        Cons.WriteLine("=== 1 - ADICIONAR ===");
        Cons.WriteLine("=== 2 - LISTAR ===");
        Cons.WriteLine("=== 3 - PROCURAR ===");
        Cons.WriteLine("=== 4 - ATUALIZAR ===");
        Cons.WriteLine("=== 5 - REMOVER ===");
        Cons.WriteLine();
        Cons.WriteLine("=== 0 - VOLTAR ===");
    }

    public static void ImprimirMenuAutores()
    {
        Cons.WriteLine("=== O QUE VOCÊ DESEJA FAZER EM AUTORES ===");
        Cons.WriteLine("=== 1 - ADICIONAR ===");
        Cons.WriteLine("=== 2 - LISTAR ===");
        Cons.WriteLine("=== 3 - PROCURAR ===");
        Cons.WriteLine("=== 4 - ATUALIZAR ===");
        Cons.WriteLine("=== 5 - REMOVER ===");
        Cons.WriteLine();
        Cons.WriteLine("=== 0 - VOLTAR ===");
    }

    public static void OpcaoInvalida()
    {
        Cons.WriteLine("Opção Inválida :(");
        PressioneEnterParaContinuar();
    }

    public static void PressioneEnterParaContinuar()
    {
        Cons.WriteLine("PRESSIONE ENTER PARA CONTINUAR");
        Cons.ReadLine();

        Cons.Clear();
    }
}